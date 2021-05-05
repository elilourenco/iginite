using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Types;
using libongo.Estatisticas;
using libongo.Helpers;
using libongo.InMemory;
using libongo.Models;
using libongo.Repositories;
using libongo.Services;
using libongo.Services.Email;
using libongo.Services.GeoLocalizacao;
using libongo.Services.Kafka;
using libongo.Services.RabbitMQ;
using libongo.Services.Redis;
using libongo.Type;

namespace libongo.GraphiQl.Config
{
  public class AppMutations : ObjectGraphType
  {
    public AppMutations(ContextServiceLocator contextServiceLocator)
    {
      //############################Api de Login #####################################
      #region Api de Login
      Field<LoginType>(
        "Login",
        arguments: new QueryArguments(
          new QueryArgument<LoginInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Login>("obj");

          // Recupera o usuário
          var user = AspNetUserspository.Get(models.UserName, new PasswordHash().EncodeTo64(models.PasswordHash), models.Email);
          // Verifica se o usuário existe
          if (user == null)
          {
            var cn = new Conecnation().GetDirectorySearch(models);
            var obj = new Authentications().Query(cn, models.UserName);

            if (obj != null)
            {
              models.UserName = obj.GetDirectoryEntry().Properties["samaccountname"].Value.ToString();
              models.Email = obj.GetDirectoryEntry().Properties["mail"].Value.ToString();
              models.City = obj.GetDirectoryEntry().Properties["l"].Value.ToString();
              models.Country = obj.GetDirectoryEntry().Properties["co"].Value.ToString();
              models.FirstName = obj.GetDirectoryEntry().Properties["givenName"].Value.ToString();
              models.LastName = obj.GetDirectoryEntry().Properties["sn"].Value.ToString();
              models.Company = obj.GetDirectoryEntry().Properties["company"].Value.ToString();
              models.TelephoneNumber = obj.GetDirectoryEntry().Properties["telephoneNumber"].Value.ToString();

              var token = TokenService.GenerateTokenActivydirectory(models.UserName, models.Email);
              models.message = "authenticated-user";
              models.token = token;
            }
            else
            {
              models.message = "invalid-username-or-password";
            }
          }

          if (user != null)
          {
            models.Id = user.Id;
            var token = TokenService.GenerateToken(user);
            // Oculta a senha
            models.PasswordHash = "";
            models.token = token;
            models.message = "authenticated-user";
          }
          return models;
        }
      );
      #endregion;
      //############################Fim Api de Login #################################

      //############################Api de authenticated #####################################
      #region Api de authenticated

      Field<LoginType>(
        "Authenticatedactivydirectory",
        arguments: new QueryArguments(
          new QueryArgument<LoginInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Login>("obj");
          return models;
        }
      );
      #endregion;
      //############################Fim Api de authenticated #################################

      #region Add dados de AspNetUsers

      Field<AspNetUsersType>(
        "addAspNetUsers",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUsersInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetUsers>("obj");
          models.PasswordHash = $"{models.UserName}@libongo.co.ao";
          models.PasswordHash = new PasswordHash().EncodeTo64(models.PasswordHash);
          var retorno = contextServiceLocator.Repository.Add<AspNetUsers>(models);
          if (retorno != null)
            new EmailService().sendEmail(models.Email, new PasswordHash().DecodeFrom64(models.PasswordHash), models.UserName);
          //new Hashco
          return retorno;
        }
      );
      #endregion

      #region Api de Geolocalizção 

      Field<GeolocalizacaoType>(
        "addGeolocalizcao",
        arguments: new QueryArguments(
          new QueryArgument<GeolocalizacaoInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<RootObject>("obj");

          var retorno = new GeoLocal().getAddress(models.lat, models.lon);

          return retorno;
        }
      );
      #endregion

      //############################Api que adicionar servicestype para uma rota
      #region Api que adicionar servicestype para uma rota
      Field<ListGraphType<RoutesType>>(
        "addMicroServiceRoutes",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RoutesInputType>> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "apiResourcesId" }
        ),
        resolve: context =>
        {

          var models = context.GetArgument<List<Routes>>("obj");
          var ApiResourcesId = context.GetArgument<string>("apiResourcesId");

          var rabbit = new RabbitMQClient(contextServiceLocator);
          var kafka = new kafkaClient();
          var redis = new RedisClients();

          if (ApiResourcesId != null && models == null)
          {
            return contextServiceLocator.Repository.selectOne(new Routes(), ApiResourcesId);
          }

          if (ApiResourcesId == null && models != null)
          {
            foreach (var objs in models)
            {

              var RoutesMethods = contextServiceLocator.Repository.selectOne(new RoutesMethods(), objs.Id);
              var microid = contextServiceLocator.Repository.selectOne(new MicroServiceConfig(), objs.ApiResourceId).FirstOrDefault();
              var service = contextServiceLocator.Repository.selectOne(new MicroServices(), microid.MicroServiceId).FirstOrDefault();

              if (service.Name == "RabbitMQ")
              {
                if (rabbit.CheckConn(microid.Ip, microid.UserName, microid.Password, microid.Port))
                {
                  foreach (var methorotes in RoutesMethods)
                  {
                    var method = contextServiceLocator.Repository.selectOne(new Methods(), methorotes.MethodId).First();
                    rabbit.createQueue(objs.Name, microid.Name, method.Name);
                  }
                  contextServiceLocator.Repository.UpDate<Routes>(objs, objs.Id);
                }
              }
              if (service.Name == "Kafka")
              {
                if (kafka.CheckConnkafka(microid.Ip, microid.Port))
                {
                  foreach (var methorotes in RoutesMethods)
                  {
                    var method = contextServiceLocator.Repository.selectOne(new Methods(), methorotes.MethodId).First();
                  }
                  contextServiceLocator.Repository.UpDate<Routes>(objs, objs.Id);
                }
              }
              if (service.Name == "Redis")
              {
                if (redis.CheckConnRedis(microid.Ip, microid.UserName, microid.Password, microid.Port))
                {
                  foreach (var methorotes in RoutesMethods)
                  {
                    var method = contextServiceLocator.Repository.selectOne(new Methods(), methorotes.MethodId).First();
                  }
                  contextServiceLocator.Repository.UpDate<Routes>(objs, objs.Id);
                }
              }

              //Falta o Kafka e o Redis
            }
            return models;
          }
          else
            return "erro";
        }
      );
      #endregion
      //############################ Fim Api que adicionar servicestype para uma rota

      //###########################Api que permite pegar os campos de uma api
      #region Api que permite pegar os campos de uma api

      FieldAsync<FieldApiType>(
        "getfieldApi",
        arguments: new QueryArguments(
          new QueryArgument<FieldApiTypeInputType> { Name = "obj" }
        ),
        resolve: async context =>
        {
          var models = context.GetArgument<FieldApi>("obj");
          var routa = contextServiceLocator.Repository.selectOne(new Routes(), models.RouteId).FirstOrDefault();

          #region  Consumir api Rest

          if (models.tipo.ToUpper() == "REST")
          {

            if (models.methodo.ToUpper() == "GET")
            {
              using (var client = new HttpClient())
              {
                var result = await client.GetAsync(models.url);
                var response = await result.Content.ReadAsStringAsync();
                if (response == null)
                  models.returnobj = "Erro de requisição";
                models.returnobj = response;
              }
            }

            if (models.methodo.ToUpper() == "POST")
            {
              using (var client = new HttpClient())
              {
                var response = string.Empty;
                HttpContent obj = new StringContent(models.obj.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync(models.url, obj);

                if (result.IsSuccessStatusCode)
                {
                  response = result.StatusCode.ToString();

                  models.returnobj = response;
                }
              }
            }

            if (models.methodo.ToUpper() == "PUT")
            {
              using (var client = new HttpClient())
              {
                var response = string.Empty;
                HttpContent obj = new StringContent(models.obj.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync(models.url, obj);
                if (result.IsSuccessStatusCode)
                {
                  response = result.StatusCode.ToString();
                  models.returnobj = response;
                }
              }
            }

            if (models.methodo.ToUpper() == "DELETE")
            {
              using (var client = new HttpClient())
              {
                var response = string.Empty;
                using (var result = await client.DeleteAsync(models.obj))
                {
                  models.returnobj = result.EnsureSuccessStatusCode().ToString();
                }
              }
            }

          }
          #endregion

          #region Consumir api graphql

          if (models.tipo.ToUpper() == "GRAPHIQL")
          {
            var SchemaRoute = contextServiceLocator.Repository.selectOne(new SchemaRoute(), routa.Id).FirstOrDefault();
            var graphQLOptions = new GraphQLHttpClientOptions
            {
              EndPoint = new Uri($"{models.url}", UriKind.Absolute),
            };
            var graphQLClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());

            #region Methodo resposnvael por executar as query no graphql ou fazer a requisição

            if (SchemaRoute.Objecto != "" || SchemaRoute.Objecto != null)
            {
              var query = new GraphQLRequest
              {
                Query = $"{SchemaRoute.Objecto}"
              };
              var graphQLResponse = await graphQLClient.SendQueryAsync<dynamic>(query).ConfigureAwait(false);
              if (models.returnobj == null)
              {
                models.returnobj = "Erro de requisição";
              }
              models.returnobj = graphQLResponse.Data;

            }
            #endregion

            #region Methodo resposnvael por executar as mutation no graphql

            if (SchemaRoute.Objecto == "" || SchemaRoute.Objecto == null)
            {
              var query = new GraphQLRequest
              {
                Query = @$"{SchemaRoute.Objecto}",
                Variables = new { obj = models.obj }
              };
              var response = await graphQLClient.SendMutationAsync<dynamic>(query).ConfigureAwait(false);
              if (models.returnobj == null)
              {
                models.returnobj = "Erro de requisição";
              }
              models.returnobj = response.Data;
            }
            #endregion
          }
          return models;
        });
      #endregion

      #endregion

      //###########################Fim Api que permite pegar os campos de uma api

      //############################Api que permite Consumir api 

      void Alertmethod(string idRoute)
      {
        var EmailService = new EmailService();
        var RouteAnalytics = new Connect().executeAd<RouteAnalytics>($"EXEC procedure_RouteAnalytics '{idRoute}'").FirstOrDefault();
        var api_resouce = new Connect().executeAd<AlertsRoute>($"EXEC AlertsRoute '{idRoute}'");

        foreach (var item in api_resouce)
        {
          if (item.AlertCondition == "Maior que (>)")
          {
            if (item.AlertType == "Número total de respostas")
            {
              if (RouteAnalytics.APICalls > item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de requisições definido", "");
            }
            if (item.AlertType == "Número total de erros")
            {
              if (RouteAnalytics.Error > item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de erros definido", "");
            }
          }

          if (item.AlertCondition == "Igual (=)")
          {
            if (item.AlertType == "Número total de respostas")
            {
              if (RouteAnalytics.APICalls == item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de requisições definido", "");
            }
            if (item.AlertType == "Número total de erros")
            {
              if (RouteAnalytics.Error == item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de erros definido", "");
            }
          }

          if (item.AlertCondition == "Menor ou igual que (<=)")
          {
            if (item.AlertType == "Número total de respostas")
            {
              if (RouteAnalytics.APICalls <= item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de requisições definido", "");
            }
            if (item.AlertType == "Número total de erros")
            {
              if (RouteAnalytics.Error <= item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de erros definido", "");
            }
          }

          if (item.AlertCondition == "Maior ou Igual (>=)")
          {
            if (item.AlertType == "Número total de respostas")
            {
              if (RouteAnalytics.APICalls >= item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de requisições definido", "");
            }
            if (item.AlertType == "Número total de erros")
            {
              if (RouteAnalytics.Error >= item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de erros definido", "");
            }
          }

          if (item.AlertCondition == "Menor que (<)")
          {
            if (item.AlertType == "Número total de respostas")
            {
              if (RouteAnalytics.APICalls < item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de requisições definido", "");
            }
            if (item.AlertType == "Número total de erros")
            {
              if (RouteAnalytics.Error < item.MetricThreshold)
                EmailService.sendEmailalert($"{item.OwnerEmail}", "Api atingiu o numero de erros definido", "");
            }
          }
        }
      }

      #region Api que permite Consumir api

      FieldAsync<ListGraphType<ApiGetWeyType>>(
        "apigetwey",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<ApiGetWeyInputType>> { Name = "obj" }
        ),
        resolve: async context =>
        {
          string _resul = "[";
          var rabbit = new RabbitMQClient(contextServiceLocator);
          var kafka = new kafkaClient();
          var redis = new RedisClients();
          var models = context.GetArgument<List<ApiGetWey>>("obj");
          var t = "";
          var RouteAnalytics = new RouteAnalytics();

          string idrout = "";

          bool verificarConexao = false;

          string comunicmicroservice(string name)
          {
            if (t == "Redis" && redis.GetCashe<string>(name) != null)
            {
              return redis.GetCashe<string>(name);
            }
            if (t == "RabbitMQ" && rabbit.Receive(name.GetType(), name) != null)
            {
              return rabbit.Receive(name.GetType(), name).ToString();
            }
            else
            {
              return null;
            }
          }

          foreach (var objmodel in models)
          {
            var retorno = new GeoLocal().getAddress(objmodel.Localizacao.lat, objmodel.Localizacao.lon);
            objmodel.Localizacao = retorno;

            var api_resouce = new Connect().executeAd<ApiResources>($"Select *from ApiResources  where Name = '{objmodel.ServiceName}' and ClientId = '{objmodel.ClientClientsId}'").FirstOrDefault();

            if (api_resouce == null)
              api_resouce = new Connect().executeAd<ApiResources>($"select ApiResources.* from ClientClientsRoutes,Routes,ApiResources where  Routes.Id=ClientClientsRoutes.RouteId and Routes.ApiResourceId=ApiResources.Id and Routes.Name='{objmodel.RouteName}' and ClientClientsId='{objmodel.ClientClientsId}'").FirstOrDefault();

            if (api_resouce != null)
            {

              var microservice = contextServiceLocator.Repository.sub_search(new MicroServiceConfig(), api_resouce.Id, new MicroServices()).FirstOrDefault();
              t = microservice.MicroServices.Name;

              #region  Consumir api Rest

              if (objmodel.tipo.ToUpper() == "REST")
              {

                _resul = "";
                var routa = new Connect().executeAd<Routes>($"Select *from Routes  where ApiResourceId='{api_resouce.Id}' and Name='{objmodel.RouteName}'").FirstOrDefault();
                idrout = routa.Id;
                RouteAnalytics.RouteId = routa.Id;

                #region Verficar as conexões com os microservices 

                if (t == "RabbitMQ")
                {
                  verificarConexao = rabbit.CheckConn(microservice.Ip, microservice.UserName, microservice.Password, microservice.Port);
                }
                if (t == "Redis")
                {
                  verificarConexao = redis.CheckConnRedis(microservice.Ip, microservice.UserName, microservice.Password, microservice.Port);
                }
                if (t == "Kafka")
                {
                  verificarConexao = kafka.CheckConnkafka(microservice.Ip, microservice.Port);
                }
                #endregion

                if (objmodel.methodo.ToUpper() == "GET")
                {
                  if (comunicmicroservice(routa.Name) != null)
                  {
                    _resul = comunicmicroservice(routa.Name);
                  }
                  else
                  {
                    using (var client = new HttpClient())
                    {
                      var result = await client.GetAsync(objmodel.url);
                      var response = await result.Content.ReadAsStringAsync();

                      if (response == null)
                      {
                        _resul = "Erro de requisição";
                        RouteAnalytics.Error = 1;
                        new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                      }

                      if (verificarConexao)
                      {
                        if (t == "RabbitMQ")
                          rabbit.Send(api_resouce.Name, routa.Name, objmodel.methodo, response);
                        if (t == "Redis")
                          redis.SendCashe(response, routa.Name);
                        new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                        _resul += response;
                      }
                    }
                  }
                }
                if (objmodel.methodo.ToUpper() == "POST")
                {
                  using (var client = new HttpClient())
                  {
                    var response = string.Empty;
                    HttpContent obj = new StringContent(objmodel.obj.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PostAsync(objmodel.url, obj);

                    if (result.IsSuccessStatusCode)
                    {
                      response = result.StatusCode.ToString();
                      if (verificarConexao)
                      {
                        if (t == "RabbitMQ")
                          rabbit.Send(api_resouce.Name, routa.Name, objmodel.methodo, response);
                        if (t == "Redis")
                          redis.SendCashe(response, routa.Name);
                      }
                      new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                      _resul = response;
                    }
                  }
                }

                if (objmodel.methodo.ToUpper() == "PUT")
                {
                  using (var client = new HttpClient())
                  {
                    var response = string.Empty;
                    HttpContent obj = new StringContent(objmodel.obj.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await client.PutAsync(objmodel.url, obj);
                    if (result.IsSuccessStatusCode)
                    {
                      response = result.StatusCode.ToString();
                      if (verificarConexao)
                      {
                        if (t == "RabbitMQ")
                          rabbit.Send(api_resouce.Name, routa.Name, objmodel.methodo, response);
                        if (t == "Redis")
                          redis.SendCashe(response, routa.Name);
                      }
                      new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                      _resul = response;
                    }
                  }
                }

                if (objmodel.methodo.ToUpper() == "DELETE")
                {
                  using (var client = new HttpClient())
                  {
                    var response = string.Empty;
                    using (var result = await client.DeleteAsync(objmodel.obj))
                    {
                      if (verificarConexao)
                      {
                        if (t == "RabbitMQ")
                          rabbit.Send(api_resouce.Name, routa.Name, objmodel.methodo, response);
                        if (t == "Redis")
                          redis.SendCashe(response, routa.Name);
                      }
                      new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                      _resul = result.EnsureSuccessStatusCode().ToString();
                    }
                  }
                }

              }
              #endregion

              #region Consumir api graphql

              if (objmodel.tipo.ToUpper() == "GRAPHIQL")
              {
               
                #region Verficar as conexões com os microservices 

                if (t == "RabbitMQ")
                {
                  verificarConexao = rabbit.CheckConn(microservice.Ip, microservice.UserName, microservice.Password, microservice.Port);
                }
                if (t == "Redis")
                {
                  verificarConexao = redis.CheckConnRedis(microservice.Ip, microservice.UserName, microservice.Password, microservice.Port);
                }
                if (t == "Kafka")
                {
                  verificarConexao = kafka.CheckConnkafka(microservice.Ip, microservice.Port);
                }
                #endregion

                var MembersRoutes = new Connect().executeAd<ClientClientsRoutes>($"Select *from Routes,ApiResources,Types,ClientClientsRoutes  where ApiResources.Id=Routes.ApiResourceId and Types.Id=ApiResources.TypeId and ClientClientsRoutes.RouteId=Routes.Id and Types.Name='graphiql' and ClientClientsRoutes.ClientClientsId='{objmodel.ClientClientsId}' and Routes.Name='{objmodel.RouteName}'");

                var graphQLOptions = new GraphQLHttpClientOptions
                {
                  EndPoint = new Uri($"{objmodel.url}", UriKind.Absolute),
                };

                var graphQLClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());

                #region Methodo resposnvael por executar as query no graphql ou fazer a requisição

                foreach (var item in MembersRoutes)
                {
                  var routa = new Connect().executeAd<Routes>($"Select *from Routes  where ApiResourceId='{api_resouce.Id}' and Id='{item.RouteId}'").FirstOrDefault();
                  RouteAnalytics.RouteId = routa.Id;
                  objmodel.Routas += routa.Name + ",";
                  var SchemaRoute = contextServiceLocator.Repository.selectOne(new SchemaRoute(), item.RouteId).FirstOrDefault();
                  var SchemaGraphQ = contextServiceLocator.Repository.selectOne(new SchemaGraphQ(), SchemaRoute.SchemaGraphQId).FirstOrDefault();

                  //SchemaRoute.Objecto != null &&

                  if (SchemaGraphQ.Name == "Query" || SchemaGraphQ.Name == "Subscription")
                  {

                    if (verificarConexao != false && comunicmicroservice(routa.Name) != null)
                    {
                      _resul += comunicmicroservice(routa.Name);

                    }
                    else
                    {
                      var query = new GraphQLRequest
                      {
                        //Query = @$"{SchemaRoute.Objecto}",
                        Query = @$"{objmodel.query}",
                        Variables = new { obj = @$"{objmodel.obj}"}
                      };

                      var graphQLResponse = await graphQLClient.SendQueryAsync<dynamic>(query).ConfigureAwait(false);

                      _resul += $"{graphQLResponse.Data},";

                      if (_resul == null)
                      {
                        _resul = "Erro de requisição";
                        RouteAnalytics.Error = 1;
                        new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                      }
                      
                      if (verificarConexao == true)
                      {
                        if (t == "RabbitMQ")
                          rabbit.Send(api_resouce.Name, routa.Name, objmodel.methodo, graphQLResponse.Data);
                        if (t == "Redis")
                          redis.SendCashe(graphQLResponse.Data, routa.Name);
                      }

                    }
                  }
                  #endregion
                }
                objmodel.Routas += ",";
                objmodel.Routas = objmodel.Routas.Replace(",,", "");

                #region Methodo resposnvael por executar as mutation no graphql

                if (objmodel.obj != null && objmodel.mutation != null)
                {
                  var query = new GraphQLRequest
                  {
                    /*
                    Query = @$"{objmodel.mutation}",
                    Variables = new { obj = objmodel.obj }
                    */
                    Query = @$"{objmodel.mutation}",
                    Variables = new { obj = objmodel.obj }

                  };
                  var response = await graphQLClient.SendMutationAsync<dynamic>(query).ConfigureAwait(false);

                  if (objmodel.returnobj == null)
                  {
                    objmodel.returnobj = "Erro de requisição";
                    RouteAnalytics.Error = 1;
                    new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
                  }
                  /*
                  else
                  {
                    if (verificarConexao)
                    {
                      if (t == "RabbitMQ")
                        rabbit.Send(api_resouce.Name, routa.Name, models.methodo, response.Data);
                      if (t == "Redis")
                        redis.SendCashe(response.Data, routa.Name);
                    }
                  }
                  */
                  _resul = "";
                  _resul += response.Data;
                }

                #endregion
              }
              if (objmodel.mutation == null && objmodel.obj == null && objmodel.tipo.ToUpper() != "REST")
              {
                _resul += ",";
                _resul = _resul.Replace(",,", "]");
              }
              objmodel.returnobj = _resul;

              if (objmodel.returnobj != null)
              {
                RouteAnalytics.APICalls = 1;
                new RouteAnalyticsMethods(contextServiceLocator).addtestatic(RouteAnalytics, objmodel.Canal, objmodel.methodo);
              }
            }
            else
            {
              objmodel.returnobj += "Nehuma routa encontrada";
            }
          }
          Alertmethod(idrout);
          return models;
        });
      #endregion

      #endregion
      //###########################Fim da api que permite consumir api

      #region Documentation

      FieldAsync<ListGraphType<ApiDocumentationType>>(
        "ApiDocumentation",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<ApiDocumentationInputType>> { Name = "obj" }
        ),
        resolve: async context =>
        {
          var models = context.GetArgument<List<ApiDocumentation>>("obj");
          try
          {
            var Documentationheader = new Documentationheader();
            var contacts = new contacts();

            foreach (var item in models)
            {
              var user = new Connect().executeAd<AspNetUsers>($"select *from AspNetUsers where ID = '{item.AspNetUsersId}'").FirstOrDefault();
              var Methods = new Connect().executeAd<Methods>($"SELECT *from RoutesMethods,Methods where  RoutesMethods.RouteId = '{item.RouteId}' and Methods.Id='{item.MethodsId}';").FirstOrDefault();
              var type = new Connect().executeAd<Types>($"select Types.* from ApiResources,Types,Routes where Routes.ApiResourceId = ApiResources.Id and ApiResources.TypeId=Types.Id and Routes.Id ='{item.RouteId}'").FirstOrDefault();

              Documentationheader.description = "Libongo Apigetway, é uma plataforma de gerenciamento de Api, Desenvolvida pela empresa de desenvolvimento SNIR, a plataforma tem como objectivo fazer o gerenciamento de Apis";
              Documentationheader.version = "1.0";
              Documentationheader.title = "LibongoGetway";
              contacts.email = user.Email;
              contacts.contact = user.PhoneNumber;
              Documentationheader.termsOfService = item.url;
              item.Documentationheader = Documentationheader;
              item.Documentationheader.contacts = contacts;

              if (type.Name.ToUpper() == "REST")
              {
                using (var client = new HttpClient())
                {

                  if (Methods.Name == "GET")
                  {
                    HttpResponseMessage sms = await client.GetAsync(item.url);

                    if (sms.EnsureSuccessStatusCode().IsSuccessStatusCode == false)
                    {
                      item.EnsureSuccessStatusCode = sms.EnsureSuccessStatusCode().ToString();
                      item.data = null;
                    }

                    if (sms.EnsureSuccessStatusCode().IsSuccessStatusCode == true)
                    {
                      var result = await client.GetAsync(item.url);
                      var response = await result.Content.ReadAsStringAsync();
                      item.data += response;
                      item.EnsureSuccessStatusCode = sms.EnsureSuccessStatusCode().ToString();
                    }
                  }
                }
              }
            }
          }
          catch (System.Exception)
          {
            throw;
          }
          return models;
        });
      #endregion
      //###########################Fim da api que permite Documentation

    }
  }
}