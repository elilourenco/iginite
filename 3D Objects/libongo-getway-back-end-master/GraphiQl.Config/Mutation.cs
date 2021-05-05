using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using libongo.Helpers;
using libongo.Models;
using libongo.Services.RabbitMQ;
//using ;
using libongo.InMemory;
using libongo.Services;
using libongo.Services.Email;
using libongo.Services.Kafka;
using libongo.Services.Redis;
using libongo.Type;
using libongo.plugin;

namespace libongo.GraphiQl.Config
{
  public class Mutation : AppMutations
  {
    public Mutation(ContextServiceLocator contextServiceLocator) : base(contextServiceLocator)
    {

      #region Add dados de ApiResourceClaims

      Field<ApiResourceClaimsType>(
        "addApiResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiResourceClaims>("obj");

          return contextServiceLocator.Repository.Add<ApiResourceClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiResourceClaims

      Field<ApiResourceClaimsType>(
        "updateApiResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResourceClaims>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResourceClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResourceClaims

      Field<StringGraphType>(
        "deleteApiResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResourceClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResourceClaims #############################################3

      #region Add dados de ApiResourceProperties

      Field<ApiResourcePropertiesType>(
        "addApiResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcePropertiesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiResourceProperties>("obj");
          return contextServiceLocator.Repository.Add<ApiResourceProperties>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiResourceProperties

      Field<ApiResourcePropertiesType>(
        "updateApiResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcePropertiesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResourceProperties>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResourceProperties>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResourceProperties

      Field<StringGraphType>(
        "deleteApiResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResourceProperties", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResourceProperties #############################################3

      #region Add dados de ApiResources

      Field<ApiResourcesType>(
        "addApiResources",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {

          var rabbit = new RabbitMQClient(contextServiceLocator);
          var kafka = new kafkaClient();
          var redis = new RedisClients();
          var models = context.GetArgument<ApiResources>("obj");
          var MicroServiceConfig = new List<MicroServiceConfig>();

          if (models.MicroServiceConfig != null)
          {
            models = contextServiceLocator.Repository.Add<ApiResources>(models);

            foreach (var item in models.MicroServiceConfig)
            {
              var microservice = contextServiceLocator.Repository.selectOne(new MicroServices(), item.MicroServiceId).FirstOrDefault();

              MicroServiceConfig.Add(item);
              if (microservice.Name == "RabbitMQ")
              {
                if (rabbit.CheckConn(item.Ip, item.UserName, item.Password, item.Port))
                {
                  item.ApiResourcesId = models.Id;
                  var retornoMicroServiceConfig = contextServiceLocator.Repository.Add<MicroServiceConfig>(item);
                  rabbit.createExchange(retornoMicroServiceConfig.Name);
                }
              }
              if (microservice.Name == "Redis")
              {
                if (redis.CheckConnRedis(item.Ip, item.UserName, item.Password, item.Port))
                {
                  item.ApiResourcesId = models.Id;
                  var retornoMicroServiceConfig = contextServiceLocator.Repository.Add<MicroServiceConfig>(item);
                }
              }
              if (microservice.Name == "Kafka")
              {
                if (kafka.CheckConnkafka(item.Ip, item.Port))
                {
                  item.ApiResourcesId = models.Id;
                  var retornoMicroServiceConfig = contextServiceLocator.Repository.Add<MicroServiceConfig>(item);
                  kafka.createTopic(retornoMicroServiceConfig.Name);
                }
              }
            }
          }
          else
          {
            models = contextServiceLocator.Repository.Add<ApiResources>(models);
          }
          models.MicroServiceConfig = MicroServiceConfig;
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  ApiResources

      Field<ApiResourcesType>(
        "updateApiResources",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResources>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResources>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResources

      Field<StringGraphType>(
        "deleteApiResources",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResources", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResources #############################################3

      #region Add dados de ApiResourceScopes

      Field<ApiResourceScopesType>(
        "addApiResourceScopes",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceScopesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiResourceScopes>("obj");
          return contextServiceLocator.Repository.Add<ApiResourceScopes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiResourceScopes

      Field<ApiResourceScopesType>(
        "updateApiResourceScopes",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceScopesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResourceScopes>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResourceScopes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResourceScopes

      Field<StringGraphType>(
        "deleteApiResourceScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResourceScopes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResourceScopes #############################################3

      #region Add dados de ApiResourceSecrets

      Field<ApiResourceSecretsType>(
        "addApiResourceSecrets",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceSecretsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiResourceSecrets>("obj");
          return contextServiceLocator.Repository.Add<ApiResourceSecrets>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiResourceSecrets

      Field<ApiResourceSecretsType>(
        "updateApiResourceSecrets",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourceSecretsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResourceSecrets>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResourceSecrets>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResourceSecrets

      Field<StringGraphType>(
        "deleteApiResourceSecrets",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResourceSecrets", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResourceSecrets #############################################3

      #region Add dados de ApiScopeClaims

      Field<ApiScopeClaimsType>(
        "addApiScopeClaims",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopeClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiScopeClaims>("obj");
          return contextServiceLocator.Repository.Add<ApiScopeClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiScopeClaims

      Field<ApiScopeClaimsType>(
        "updateApiScopeClaims",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopeClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiScopeClaims>("obj");
          return contextServiceLocator.Repository.UpDate<ApiScopeClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiScopeClaims

      Field<StringGraphType>(
        "deleteApiScopeClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiScopeClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiScopeClaims #############################################3

      #region Add dados de ApiScopeProperties

      Field<ApiScopePropertiesType>(
        "addApiScopeProperties",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopePropertiesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiScopeProperties>("obj");
          return contextServiceLocator.Repository.Add<ApiScopeProperties>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiScopeProperties

      Field<ApiScopePropertiesType>(
        "updateApiScopeProperties",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopePropertiesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiScopeProperties>("obj");
          return contextServiceLocator.Repository.UpDate<ApiScopeProperties>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiScopeProperties

      Field<StringGraphType>(
        "deleteApiScopeProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiScopeProperties", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiScopeProperties #############################################3

      #region Add dados de ApiScopes

      Field<ApiScopesType>(
        "addApiScopes",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiScopes>("obj");
          return contextServiceLocator.Repository.Add<ApiScopes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiScopes

      Field<ApiScopesType>(
        "updateApiScopes",
        arguments: new QueryArguments(
          new QueryArgument<ApiScopesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiScopes>("obj");
          return contextServiceLocator.Repository.UpDate<ApiScopes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiScopes

      Field<StringGraphType>(
        "deleteApiScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiScopes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiScopes #############################################3

      #region Add dados de AspNetRoleClaims

      Field<AspNetRoleClaimsType>(
        "addAspNetRoleClaims",
        arguments: new QueryArguments(
          new QueryArgument<AspNetRoleClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetRoleClaims>("obj");
          return contextServiceLocator.Repository.Add<AspNetRoleClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AspNetRoleClaims

      Field<AspNetRoleClaimsType>(
        "updateAspNetRoleClaims",
        arguments: new QueryArguments(
          new QueryArgument<AspNetRoleClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AspNetRoleClaims>("obj");
          return contextServiceLocator.Repository.UpDate<AspNetRoleClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetRoleClaims

      Field<StringGraphType>(
        "deleteAspNetRoleClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetRoleClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetRoleClaims #############################################3

      #region Add dados de AspNetRoles

      Field<AspNetRolesType>(
        "addAspNetRoles",
        arguments: new QueryArguments(
          new QueryArgument<AspNetRolesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetRoles>("obj");
          return contextServiceLocator.Repository.Add<AspNetRoles>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AspNetRoles

      Field<AspNetRolesType>(
        "updateAspNetRoles",
        arguments: new QueryArguments(
          new QueryArgument<AspNetRolesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AspNetRoles>("obj");
          return contextServiceLocator.Repository.UpDate<AspNetRoles>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetRoles

      Field<StringGraphType>(
        "deleteAspNetRoles",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetRoles", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetRoles #############################################3

      #region Add dados de AspNetUserClaims

      Field<AspNetUserClaimsType>(
        "addAspNetUserClaims",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetUserClaims>("obj");
          return contextServiceLocator.Repository.Add<AspNetUserClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AspNetUserClaims

      Field<AspNetUserClaimsType>(
        "updateAspNetUserClaims",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AspNetUserClaims>("obj");
          return contextServiceLocator.Repository.UpDate<AspNetUserClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetUserClaims

      Field<StringGraphType>(
        "deleteAspNetUserClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetUserClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetUserClaims #############################################3

      #region Add dados de AspNetUserRoles

      Field<AspNetUserRolesType>(
        "addAspNetUserRoles",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserRolesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetUserRoles>("obj");
          return contextServiceLocator.Repository.Add<AspNetUserRoles>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AspNetUserRoles

      Field<AspNetUserRolesType>(
        "updateAspNetUserRoles",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserRolesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AspNetUserRoles>("obj");
          return contextServiceLocator.Repository.UpDate<AspNetUserRoles>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetUserRoles

      Field<StringGraphType>(
        "deleteAspNetUserRoles",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetUserRoles", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetUserRoles #############################################3

      #region Update Date de dados  AspNetUsers

      Field<AspNetUsersType>(
        "updateAspNetUsers",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUsersInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          var model = context.GetArgument<AspNetUsers>("obj");
          model.PasswordHash = new PasswordHash().EncodeTo64(model.PasswordHash);
          return contextServiceLocator.Repository.UpDate<AspNetUsers>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetUsers

      Field<StringGraphType>(
        "deleteAspNetUsers",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetUsers", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetUsers #############################################3

      #region Add dados de AspNetUserTokens

      Field<AspNetUserTokensType>(
        "addAspNetUserTokens",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserTokensInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AspNetUserTokens>("obj");
          return contextServiceLocator.Repository.Add<AspNetUserTokens>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AspNetUserTokens

      Field<AspNetUserTokensType>(
        "updateAspNetUserTokens",
        arguments: new QueryArguments(
          new QueryArgument<AspNetUserTokensInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AspNetUserTokens>("obj");
          return contextServiceLocator.Repository.UpDate<AspNetUserTokens>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AspNetUserTokens

      Field<StringGraphType>(
        "deleteAspNetUserTokens",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AspNetUserTokens", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AspNetUserTokens #############################################3

      #region Add dados de ClientClaims

      Field<ClientClaimsType>(
        "addClientClaims",
        arguments: new QueryArguments(
          new QueryArgument<ClientClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientClaims>("obj");

          return contextServiceLocator.Repository.Add<ClientClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientClaims

      Field<ClientClaimsType>(
        "updateClientClaims",
        arguments: new QueryArguments(
          new QueryArgument<ClientClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientClaims>("obj");
          return contextServiceLocator.Repository.UpDate<ClientClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientClaims

      Field<StringGraphType>(
        "deleteClientClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientClaims #############################################3

      #region Add dados de ClientCorsOrigins

      Field<ClientCorsOriginsType>(
        "addClientCorsOrigins",
        arguments: new QueryArguments(
          new QueryArgument<ClientCorsOriginsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientCorsOrigins>("obj");
          return contextServiceLocator.Repository.Add<ClientCorsOrigins>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientCorsOrigins

      Field<ClientCorsOriginsType>(
        "updateClientCorsOrigins",
        arguments: new QueryArguments(
          new QueryArgument<ClientCorsOriginsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientCorsOrigins>("obj");
          return contextServiceLocator.Repository.UpDate<ClientCorsOrigins>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientCorsOrigins

      Field<StringGraphType>(
        "deleteClientCorsOrigins",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientCorsOrigins", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientCorsOrigins #############################################3

      #region Add dados de ClientGrantTypes

      Field<ClientGrantTypesType>(
        "addClientGrantTypes",
        arguments: new QueryArguments(
          new QueryArgument<ClientGrantTypesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientGrantTypes>("obj");
          return contextServiceLocator.Repository.Add<ClientGrantTypes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientGrantTypes

      Field<ClientGrantTypesType>(
        "updateClientGrantTypes",
        arguments: new QueryArguments(
          new QueryArgument<ClientGrantTypesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientGrantTypes>("obj");
          return contextServiceLocator.Repository.UpDate<ClientGrantTypes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientGrantTypes

      Field<StringGraphType>(
        "deleteClientGrantTypes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientGrantTypes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientGrantTypes #############################################3

      #region Add dados de ClientIdPRestrictions

      Field<ClientIdPRestrictionsType>(
        "addClientIdPRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<ClientIdPRestrictionsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientIdPRestrictions>("obj");
          return contextServiceLocator.Repository.Add<ClientIdPRestrictions>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientIdPRestrictions

      Field<ClientIdPRestrictionsType>(
        "updateClientIdPRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<ClientIdPRestrictionsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientIdPRestrictions>("obj");
          return contextServiceLocator.Repository.UpDate<ClientIdPRestrictions>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientIdPRestrictions

      Field<StringGraphType>(
        "deleteClientIdPRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientIdPRestrictions", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientIdPRestrictions #############################################3

      #region Add dados de ClientPostLogoutRedirectUris

      Field<ClientPostLogoutRedirectUrisType>(
        "addClientPostLogoutRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<ClientPostLogoutRedirectUrisInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientPostLogoutRedirectUris>("obj");
          return contextServiceLocator.Repository.Add<ClientPostLogoutRedirectUris>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientPostLogoutRedirectUris

      Field<ClientPostLogoutRedirectUrisType>(
        "updateClientPostLogoutRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<ClientPostLogoutRedirectUrisInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientPostLogoutRedirectUris>("obj");
          return contextServiceLocator.Repository.UpDate<ClientPostLogoutRedirectUris>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientPostLogoutRedirectUris

      Field<StringGraphType>(
        "deleteClientPostLogoutRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientPostLogoutRedirectUris", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientPostLogoutRedirectUris #############################################3

      #region Add dados de ClientProperties

      Field<ClientPropertiesType>(
        "addClientProperties",
        arguments: new QueryArguments(
          new QueryArgument<ClientPropertiesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientProperties>("obj");
          return contextServiceLocator.Repository.Add<ClientProperties>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientProperties

      Field<ClientPropertiesType>(
        "updateClientProperties",
        arguments: new QueryArguments(
          new QueryArgument<ClientPropertiesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientProperties>("obj");
          return contextServiceLocator.Repository.UpDate<ClientProperties>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientProperties

      Field<StringGraphType>(
        "deleteClientProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientProperties", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientProperties #############################################3

      #region Add dados de ClientRedirectUris

      Field<ClientRedirectUrisType>(
        "addClientRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<ClientRedirectUrisInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientRedirectUris>("obj");
          return contextServiceLocator.Repository.Add<ClientRedirectUris>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientRedirectUris

      Field<ClientRedirectUrisType>(
        "updateClientRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<ClientRedirectUrisInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientRedirectUris>("obj");
          return contextServiceLocator.Repository.UpDate<ClientRedirectUris>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientRedirectUris

      Field<StringGraphType>(
        "deleteClientRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientRedirectUris", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientRedirectUris #############################################3

      #region Add dados de Clients

      Field<ClientsType>(
        "addClients",
        arguments: new QueryArguments(
          new QueryArgument<ClientsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Clients>("obj");
          return contextServiceLocator.Repository.Add<Clients>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Clients

      Field<ClientsType>(
        "updateClients",
        arguments: new QueryArguments(
          new QueryArgument<ClientsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Clients>("obj");
          return contextServiceLocator.Repository.UpDate<Clients>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Clients

      Field<StringGraphType>(
        "deleteClients",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Clients", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Clients #############################################3

      #region Add dados de ClientScopes

      Field<ClientScopesType>(
        "addClientScopes",
        arguments: new QueryArguments(
          new QueryArgument<ClientScopesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientScopes>("obj");
          return contextServiceLocator.Repository.Add<ClientScopes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientScopes

      Field<ClientScopesType>(
        "updateClientScopes",
        arguments: new QueryArguments(
          new QueryArgument<ClientScopesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientScopes>("obj");
          return contextServiceLocator.Repository.UpDate<ClientScopes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientScopes

      Field<StringGraphType>(
        "deleteClientScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientScopes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientScopes #############################################3

      #region Add dados de ClientSecrets

      Field<ClientSecretsType>(
        "addClientSecrets",
        arguments: new QueryArguments(
          new QueryArgument<ClientSecretsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientSecrets>("obj");
          return contextServiceLocator.Repository.Add<ClientSecrets>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ClientSecrets

      Field<ClientSecretsType>(
        "updateClientSecrets",
        arguments: new QueryArguments(
          new QueryArgument<ClientSecretsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientSecrets>("obj");
          return contextServiceLocator.Repository.UpDate<ClientSecrets>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ClientSecrets

      Field<StringGraphType>(
        "deleteClientSecrets",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientSecrets", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ClientSecrets #############################################3

      #region Add dados de DeviceCodes

      Field<DeviceCodesType>(
        "addDeviceCodes",
        arguments: new QueryArguments(
          new QueryArgument<DeviceCodesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<DeviceCodes>("obj");
          return contextServiceLocator.Repository.Add<DeviceCodes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  DeviceCodes

      Field<DeviceCodesType>(
        "updateDeviceCodes",
        arguments: new QueryArguments(
          new QueryArgument<DeviceCodesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<DeviceCodes>("obj");
          return contextServiceLocator.Repository.UpDate<DeviceCodes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  DeviceCodes

      Field<StringGraphType>(
        "deleteDeviceCodes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("DeviceCodes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela DeviceCodes #############################################3

      #region Add dados de IdentityResourceClaims

      Field<IdentityResourceClaimsType>(
        "addIdentityResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourceClaimsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<IdentityResourceClaims>("obj");
          return contextServiceLocator.Repository.Add<IdentityResourceClaims>(models);
        }
      );

      #endregion;

      #region Update Date de dados  IdentityResourceClaims

      Field<IdentityResourceClaimsType>(
        "updateIdentityResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourceClaimsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<IdentityResourceClaims>("obj");
          return contextServiceLocator.Repository.UpDate<IdentityResourceClaims>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  IdentityResourceClaims

      Field<StringGraphType>(
        "deleteIdentityResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("IdentityResourceClaims", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela IdentityResourceClaims #############################################3

      #region Add dados de IdentityResourceProperties

      Field<IdentityResourcePropertiesType>(
        "addIdentityResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourcePropertiesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<IdentityResourceProperties>("obj");
          return contextServiceLocator.Repository.Add<IdentityResourceProperties>(models);
        }
      );

      #endregion;

      #region Update Date de dados  IdentityResourceProperties

      Field<IdentityResourcePropertiesType>(
        "updateIdentityResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourcePropertiesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<IdentityResourceProperties>("obj");
          return contextServiceLocator.Repository.UpDate<IdentityResourceProperties>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  IdentityResourceProperties

      Field<StringGraphType>(
        "deleteIdentityResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("IdentityResourceProperties", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela IdentityResourceProperties #############################################3

      #region Add dados de IdentityResources

      Field<IdentityResourcesType>(
        "addIdentityResources",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourcesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<IdentityResources>("obj");
          return contextServiceLocator.Repository.Add<IdentityResources>(models);
        }
      );

      #endregion;

      #region Update Date de dados  IdentityResources

      Field<IdentityResourcesType>(
        "updateIdentityResources",
        arguments: new QueryArguments(
          new QueryArgument<IdentityResourcesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<IdentityResources>("obj");
          return contextServiceLocator.Repository.UpDate<IdentityResources>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  IdentityResources

      Field<StringGraphType>(
        "deleteIdentityResources",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("IdentityResources", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela IdentityResources #############################################3

      #region Add dados de PersistedGrants

      Field<PersistedGrantsType>(
        "addPersistedGrants",
        arguments: new QueryArguments(
          new QueryArgument<PersistedGrantsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<PersistedGrants>("obj");
          return contextServiceLocator.Repository.Add<PersistedGrants>(models);
        }
      );

      #endregion;

      #region Update Date de dados  PersistedGrants

      Field<PersistedGrantsType>(
        "updatePersistedGrants",
        arguments: new QueryArguments(
          new QueryArgument<PersistedGrantsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<PersistedGrants>("obj");
          return contextServiceLocator.Repository.UpDate<PersistedGrants>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  PersistedGrants

      Field<StringGraphType>(
        "deletePersistedGrants",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("PersistedGrants", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela PersistedGrants #############################################3

      #region Add dados de Members

      Field<ClientClientsType>(
        "addClientClients",
        arguments: new QueryArguments(
          new QueryArgument<ClientClientsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ClientClients>("obj");
          var pessoa = contextServiceLocator.Repository.Add<Persons>(models.Persons);
          models.PersonId = pessoa.Id;
          return contextServiceLocator.Repository.Add<ClientClients>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Members

      Field<ClientClientsType>(
        "updateClientClients",
        arguments: new QueryArguments(
          new QueryArgument<ClientClientsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientClients>("obj");
          return contextServiceLocator.Repository.UpDate<ClientClients>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Members

      Field<StringGraphType>(
        "deleteClientClients",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Members", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Members #############################################3

      #region Add dados de MembersRoutes

      Field<ListGraphType<ClientClientsRoutesType>>(
        "addClientClientsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<ClientClientsRoutesInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<ClientClientsRoutes>>("obj");

          foreach (var obj in models)
          {
            contextServiceLocator.Repository.Add<ClientClientsRoutes>(obj);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  MembersRoutes

      Field<ClientClientsRoutesType>(
        "updateClientClientsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<ClientClientsRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ClientClientsRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<ClientClientsRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MembersRoutes

      Field<StringGraphType>(
        "deleteClientClientsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ClientClientsRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MembersRoutes #############################################3

      #region Add dados de Protocols

      Field<ProtocolsType>(
        "addProtocols",
        arguments: new QueryArguments(
          new QueryArgument<ProtocolsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Protocols>("obj");
          return contextServiceLocator.Repository.Add<Protocols>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Protocols

      Field<ProtocolsType>(
        "updateProtocols",
        arguments: new QueryArguments(
          new QueryArgument<ProtocolsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Protocols>("obj");
          return contextServiceLocator.Repository.UpDate<Protocols>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Protocols

      Field<StringGraphType>(
        "deleteProtocols",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Protocols", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Protocols #############################################3

      #region Add dados de ApiResourcesTags

      Field<ApiResourcesTagsType>(
        "addApiResourcesTags",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcesTagsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ApiResourcesTags>("obj");
          return contextServiceLocator.Repository.Add<ApiResourcesTags>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ApiResourcesTags

      Field<ApiResourcesTagsType>(
        "updateApiResourcesTags",
        arguments: new QueryArguments(
          new QueryArgument<ApiResourcesTagsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ApiResourcesTags>("obj");
          return contextServiceLocator.Repository.UpDate<ApiResourcesTags>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ApiResourcesTags

      Field<StringGraphType>(
        "deleteApiResourcesTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ApiResourcesTags", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ApiResourcesTags #############################################3

      #region Add dados de Paths

      Field<ListGraphType<PathsType>>(
        "addPaths",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<PathsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<Paths>>("obj");
          foreach (var obj in models)
          {
            contextServiceLocator.Repository.Add<Paths>(obj);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  Paths

      Field<PathsType>(
        "updatePaths",
        arguments: new QueryArguments(
          new QueryArgument<PathsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Paths>("obj");
          return contextServiceLocator.Repository.UpDate<Paths>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Paths

      Field<StringGraphType>(
        "deletePaths",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Paths", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Paths #############################################3

      #region Add dados de Routes

      Field<RoutesType>(
        "addRoutes",
        arguments: new QueryArguments(
          new QueryArgument<RoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Routes>("obj");
          var routes = contextServiceLocator.Repository.Add<Routes>(models);
          /*
          if (models.SchemaRoute != null)
          {
            foreach (var obj in models.SchemaRoute)
            {
              obj.RouteId = routes.Id;
              contextServiceLocator.Repository.Add<SchemaRoute>(obj);
            }
          }
          */
          if (models.RoutesCanal != null)
          {
            foreach (var obj in models.RoutesCanal)
            {
              obj.RouteId = routes.Id;
              contextServiceLocator.Repository.Add<RoutesCanal>(obj);
            }
          }

          return models;
        }
      );

      #endregion;

      #region Update Date de dados  Routes

      Field<RoutesType>(
        "updateRoutes",
        arguments: new QueryArguments(
          new QueryArgument<RoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Routes>("obj");
          return contextServiceLocator.Repository.UpDate<Routes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Routes

      Field<StringGraphType>(
        "deleteRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Routes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Routes #############################################3

      #region Add dados de Methods

      Field<MethodsType>(
        "addMethods",
        arguments: new QueryArguments(
          new QueryArgument<MethodsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Methods>("obj");
          return contextServiceLocator.Repository.Add<Methods>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Methods

      Field<MethodsType>(
        "updateMethods",
        arguments: new QueryArguments(
          new QueryArgument<MethodsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Methods>("obj");
          return contextServiceLocator.Repository.UpDate<Methods>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Methods

      Field<StringGraphType>(
        "deleteMethods",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Methods", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Methods #############################################3

      #region Add dados de RoutesMethods

      Field<ListGraphType<RoutesMethodsType>>(
        "addRoutesMethods",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RoutesMethodsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<RoutesMethods>>("obj");
          foreach (var obj in models)
          {
            contextServiceLocator.Repository.Add<RoutesMethods>(obj);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  RoutesMethods

      Field<RoutesMethodsType>(
        "updateRoutesMethods",
        arguments: new QueryArguments(
          new QueryArgument<RoutesMethodsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RoutesMethods>("obj");
          return contextServiceLocator.Repository.UpDate<RoutesMethods>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RoutesMethods

      Field<StringGraphType>(
        "deleteRoutesMethods",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("RoutesMethods", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RoutesMethods #############################################3

      #region Add dados de Headers

      Field<HeadersType>(
        "addHeaders",
        arguments: new QueryArguments(
          new QueryArgument<HeadersInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Headers>("obj");
          return contextServiceLocator.Repository.Add<Headers>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Headers

      Field<HeadersType>(
        "updateHeaders",
        arguments: new QueryArguments(
          new QueryArgument<HeadersInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Headers>("obj");
          return contextServiceLocator.Repository.UpDate<Headers>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Headers

      Field<StringGraphType>(
        "deleteHeaders",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Headers", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Headers #############################################3

      #region Add dados de HeadersRoutes

      Field<HeadersRoutesType>(
        "addHeadersRoutes",
        arguments: new QueryArguments(
          new QueryArgument<HeadersRoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<HeadersRoutes>("obj");
          return contextServiceLocator.Repository.Add<HeadersRoutes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  HeadersRoutes

      Field<HeadersRoutesType>(
        "updateHeadersRoutes",
        arguments: new QueryArguments(
          new QueryArgument<HeadersRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<HeadersRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<HeadersRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  HeadersRoutes

      Field<StringGraphType>(
        "deleteHeadersRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("HeadersRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela HeadersRoutes #############################################3

      #region Add dados de PathsRoutes

      Field<PathsRoutesType>(
        "addPathsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<PathsRoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<PathsRoutes>("obj");
          return contextServiceLocator.Repository.Add<PathsRoutes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  PathsRoutes

      Field<PathsRoutesType>(
        "updatePathsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<PathsRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<PathsRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<PathsRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  PathsRoutes

      Field<StringGraphType>(
        "deletePathsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("PathsRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela PathsRoutes #############################################3

      #region Add dados de RoutesTags

      Field<RoutesTagsType>(
        "addRoutesTags",
        arguments: new QueryArguments(
          new QueryArgument<RoutesTagsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<RoutesTags>("obj");
          return contextServiceLocator.Repository.Add<RoutesTags>(models);
        }
      );

      #endregion;

      #region Update Date de dados  RoutesTags

      Field<RoutesTagsType>(
        "updateRoutesTags",
        arguments: new QueryArguments(
          new QueryArgument<RoutesTagsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RoutesTags>("obj");
          return contextServiceLocator.Repository.UpDate<RoutesTags>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RoutesTags

      Field<StringGraphType>(
        "deleteRoutesTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("RoutesTags", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RoutesTags #############################################3

      #region Add dados de Tags

      Field<TagsType>(
        "addTags",
        arguments: new QueryArguments(
          new QueryArgument<TagsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Tags>("obj");
          return contextServiceLocator.Repository.Add<Tags>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Tags

      Field<TagsType>(
        "updateTags",
        arguments: new QueryArguments(
          new QueryArgument<TagsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Tags>("obj");
          return contextServiceLocator.Repository.UpDate<Tags>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Tags

      Field<StringGraphType>(
        "deleteTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Tags", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Tags #############################################3

      #region Add dados de Service

      Field<ServiceType>(
        "addService",
        arguments: new QueryArguments(
          new QueryArgument<ServiceInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Service>("obj");
          return contextServiceLocator.Repository.Add<Service>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Service

      Field<ServiceType>(
        "updateService",
        arguments: new QueryArguments(
          new QueryArgument<ServiceInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Service>("obj");
          return contextServiceLocator.Repository.UpDate<Service>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Service

      Field<StringGraphType>(
        "deleteService",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Service", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Service #############################################3

      #region Add dados de MicroServiceType

      Field<MicroServiceTypeType>(
        "addMicroServiceType",
        arguments: new QueryArguments(
          new QueryArgument<MicroServiceTypeInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MicroServiceType>("obj");
          return contextServiceLocator.Repository.Add<MicroServiceType>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MicroServiceType

      Field<MicroServiceTypeType>(
        "updateMicroServiceType",
        arguments: new QueryArguments(
          new QueryArgument<MicroServiceTypeInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MicroServiceType>("obj");
          return contextServiceLocator.Repository.UpDate<MicroServiceType>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MicroServiceType

      Field<StringGraphType>(
        "deleteMicroServiceType",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MicroServiceType", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ServiceTYPE #############################################3

      #region Add dados de Queue

      Field<QueueType>(
        "addQueue",
        arguments: new QueryArguments(
          new QueryArgument<QueueInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Queue>("obj");
          return contextServiceLocator.Repository.Add<Queue>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Queue

      Field<QueueType>(
        "updateQueue",
        arguments: new QueryArguments(
          new QueryArgument<QueueInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Queue>("obj");
          return contextServiceLocator.Repository.UpDate<Queue>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Queue

      Field<StringGraphType>(
        "deleteQueue",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Queue", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Queue #############################################3

      #region Add dados de MethodQueue

      Field<MethodQueueType>(
        "addMethodQueue",
        arguments: new QueryArguments(
          new QueryArgument<MethodQueueInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MethodQueue>("obj");
          return contextServiceLocator.Repository.Add<MethodQueue>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MethodQueue

      Field<MethodQueueType>(
        "updateMethodQueue",
        arguments: new QueryArguments(
          new QueryArgument<MethodQueueInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MethodQueue>("obj");
          return contextServiceLocator.Repository.UpDate<MethodQueue>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MethodQueue

      Field<StringGraphType>(
        "deleteMethodQueue",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MethodQueue", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MethodQueue #############################################3

      #region Add dados de Types

      Field<TypesType>(
        "addTypes",
        arguments: new QueryArguments(
          new QueryArgument<TypesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Types>("obj");
          return contextServiceLocator.Repository.Add<Types>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Types

      Field<TypesType>(
        "updateTypes",
        arguments: new QueryArguments(
          new QueryArgument<TypesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Types>("obj");
          return contextServiceLocator.Repository.UpDate<Types>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Types

      Field<StringGraphType>(
        "deleteTypes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Types", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Types #############################################3

      #region Add dados de RouteProtocols

      Field<ListGraphType<RouteProtocolsType>>(
        "addRouteProtocols",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RouteProtocolsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<RouteProtocols>>("obj");

          foreach (var objs in models)
          {
            contextServiceLocator.Repository.Add<RouteProtocols>(objs);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  RouteProtocols

      Field<RouteProtocolsType>(
        "updateRouteProtocols",
        arguments: new QueryArguments(
          new QueryArgument<RouteProtocolsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RouteProtocols>("obj");
          return contextServiceLocator.Repository.UpDate<RouteProtocols>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RouteProtocols

      Field<StringGraphType>(
        "deleteRouteProtocols",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("RouteProtocols", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RouteProtocols #############################################3

      #region Add dados de Hosts

      Field<ListGraphType<HostsType>>(
        "addHosts",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<HostsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<Hosts>>("obj");
          foreach (var objs in models)
          {
            contextServiceLocator.Repository.Add<Hosts>(objs);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  Hosts

      Field<HostsType>(
        "updateHosts",
        arguments: new QueryArguments(
          new QueryArgument<HostsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Hosts>("obj");
          return contextServiceLocator.Repository.UpDate<Hosts>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Hosts

      Field<StringGraphType>(
        "deleteHosts",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Hosts", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Hosts #############################################3

      #region Add dados de MicroServices
      Field<MicroServicesType>(
        "addMicroServices",
        arguments: new QueryArguments(
          new QueryArgument<MicroServicesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MicroServices>("obj");
          return contextServiceLocator.Repository.Add<MicroServices>(models); ;
        }
      );

      #endregion;

      #region Update Date de dados  MicroServices

      Field<MicroServicesType>(
        "updateMicroServices",
        arguments: new QueryArguments(
          new QueryArgument<MicroServicesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MicroServices>("obj");
          return contextServiceLocator.Repository.UpDate<MicroServices>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MicroServices

      Field<StringGraphType>(
        "deleteMicroServices",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MicroServices", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MicroServices #############################################3

      #region Add dados de MicroServiceConfig
      Field<MicroServiceConfigType>(
        "addMicroServiceConfig",
        arguments: new QueryArguments(
          new QueryArgument<MicroServiceConfigInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MicroServiceConfig>("obj");
          return contextServiceLocator.Repository.Add<MicroServiceConfig>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MicroServiceConfig

      Field<MicroServiceConfigType>(
        "updateMicroServiceConfig",
        arguments: new QueryArguments(
          new QueryArgument<MicroServiceConfigInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MicroServiceConfig>("obj");
          return contextServiceLocator.Repository.UpDate<MicroServiceConfig>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MicroServiceConfig

      Field<StringGraphType>(
        "deleteMicroServiceConfig",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MicroServiceConfig", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MicroServices #############################################3

      #region Add dados de AmbientTypes

      Field<AmbientTypesType>(
        "addAmbientTypes",
        arguments: new QueryArguments(
          new QueryArgument<AmbientTypesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<AmbientTypes>("obj");
          return contextServiceLocator.Repository.Add<AmbientTypes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  AmbientTypes

      Field<AmbientTypesType>(
        "updateAmbientTypes",
        arguments: new QueryArguments(
          new QueryArgument<AmbientTypesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<AmbientTypes>("obj");
          return contextServiceLocator.Repository.UpDate<AmbientTypes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  AmbientTypes

      Field<StringGraphType>(
        "deleteAmbientTypes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("AmbientTypes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela AmbientTypes #############################################3

      #region Add dados de CategoryRoutes

      Field<CategoryRoutesType>(
        "addCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<CategoryRoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<CategoryRoutes>("obj");
          return contextServiceLocator.Repository.Add<CategoryRoutes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  CategoryRoutes

      Field<CategoryRoutesType>(
        "updateCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<CategoryRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<CategoryRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<CategoryRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  CategoryRoutes

      Field<StringGraphType>(
        "deleteCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("CategoryRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela CategoryRoutes #############################################3

      #region Add dados de SubCategoryRoutes

      Field<SubCategoryRoutesType>(
        "addSubCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<SubCategoryRoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<SubCategoryRoutes>("obj");
          return contextServiceLocator.Repository.Add<SubCategoryRoutes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  SubCategoryRoutes

      Field<SubCategoryRoutesType>(
        "updateSubCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<SubCategoryRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SubCategoryRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<SubCategoryRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SubCategoryRoutes

      Field<StringGraphType>(
        "deleteSubCategoryRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SubCategoryRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SubCategoryRoutes #############################################3

      #region Add dados de Fields

      Field<ListGraphType<FieldsType>>(
        "addFields",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<FieldsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<Fields>>("obj");

          foreach (var obj in models)
          {
            var fields = contextServiceLocator.Repository.Add<Fields>(obj);

            foreach (var ob in obj.Restrictions)
            {
              ob.FieldsId = fields.Id;
              contextServiceLocator.Repository.Add<Restrictions>(ob);
            }
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  Fields

      Field<FieldsType>(
        "updateFields",
        arguments: new QueryArguments(
          new QueryArgument<FieldsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Fields>("obj");
          return contextServiceLocator.Repository.UpDate<Fields>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Fields

      Field<StringGraphType>(
        "deleteFields",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Fields", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Fields #############################################3

      #region Add dados de Restrictions

      Field<RestrictionsType>(
        "addRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<RestrictionsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Restrictions>("obj");
          return contextServiceLocator.Repository.Add<Restrictions>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Restrictions

      Field<RestrictionsType>(
        "updateRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<RestrictionsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Restrictions>("obj");
          return contextServiceLocator.Repository.UpDate<Restrictions>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Restrictions

      Field<StringGraphType>(
        "deleteRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Restrictions", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Restrictions #############################################3

      #region Add dados de SchemaGraphQ

      Field<SchemaGraphQType>(
        "addSchemaGraphQ",
        arguments: new QueryArguments(
          new QueryArgument<SchemaGraphQInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<SchemaGraphQ>("obj");
          return contextServiceLocator.Repository.Add<SchemaGraphQ>(models);
        }
      );

      #endregion;

      #region Update Date de dados  SchemaGraphQ

      Field<SchemaGraphQType>(
        "updateSchemaGraphQ",
        arguments: new QueryArguments(
          new QueryArgument<SchemaGraphQInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SchemaGraphQ>("obj");
          return contextServiceLocator.Repository.UpDate<SchemaGraphQ>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SchemaGraphQ

      Field<StringGraphType>(
        "deleteSchemaGraphQ",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SchemaGraphQ", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SchemaGraphQ #############################################3

      #region Add dados de SchemaRoute

      Field<ListGraphType<SchemaRouteType>>(
        "addSchemaRoute",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<SchemaRouteInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<SchemaRoute>>("obj");
          foreach (var obj in models)
          {
            contextServiceLocator.Repository.Add<SchemaRoute>(obj);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  SchemaRoute

      Field<SchemaRouteType>(
        "updateSchemaRoute",
        arguments: new QueryArguments(
          new QueryArgument<SchemaRouteInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SchemaRoute>("obj");
          return contextServiceLocator.Repository.UpDate<SchemaRoute>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SchemaRoute

      Field<StringGraphType>(
        "deleteSchemaRoute",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SchemaRoute", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SchemaRoute #############################################3

      #region Add dados de Members

      Field<MembersType>(
        "addMembers",
        arguments: new QueryArguments(
          new QueryArgument<MembersInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Members>("obj");
          var pessoa = contextServiceLocator.Repository.Add<Persons>(models.Persons);
          models.PersonsId = pessoa.Id;

          return contextServiceLocator.Repository.Add<Members>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Members

      Field<MembersType>(
        "updateMembers",
        arguments: new QueryArguments(
          new QueryArgument<MembersInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Members>("obj");
          return contextServiceLocator.Repository.UpDate<Members>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Members

      Field<StringGraphType>(
        "deleteMembers",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Members", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Members #############################################3

      #region Add dados de MembersClientClients

      Field<MembersClientType>(
        "addMembersClient",
        arguments: new QueryArguments(
          new QueryArgument<MembersClientInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MembersClient>("obj");

          var pessoa = contextServiceLocator.Repository.Add<Persons>(models.Persons);
          models.PersonsId = pessoa.Id;

          var ps = System.Guid.NewGuid().ToString();

          models.AspNetUsers.PasswordHash = ps.Substring(0, 8) + "@libongo.co.ao";
          models.AspNetUsers.PasswordHash = new PasswordHash().EncodeTo64(models.AspNetUsers.PasswordHash);
          models.AspNetUsers.PersonsId = pessoa.Id;
          var retorno = contextServiceLocator.Repository.Add<AspNetUsers>(models.AspNetUsers);

          if (retorno != null)
            new EmailService().sendEmail(models.AspNetUsers.Email, new PasswordHash().DecodeFrom64(models.AspNetUsers.PasswordHash), models.AspNetUsers.UserName);
          //new Hashco
          return contextServiceLocator.Repository.Add<MembersClient>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MembersClientClients

      Field<MembersClientType>(
        "updateMembersClient",
        arguments: new QueryArguments(
          new QueryArgument<MembersClientInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MembersClient>("obj");
          return contextServiceLocator.Repository.UpDate<MembersClient>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MembersClientClients

      Field<StringGraphType>(
        "deleteMembersClient",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MembersClient", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MembersClientClients #############################################3

      #region Add dados de ActividadeEmpresa

      Field<ActivityCompanyType>(
        "addActivityCompany",
        arguments: new QueryArguments(
          new QueryArgument<ActivityCompanyInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ActivityCompany>("obj");
          return contextServiceLocator.Repository.Add<ActivityCompany>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ActivityCompany

      Field<ActivityCompanyType>(
        "updateActivityCompany",
        arguments: new QueryArguments(
          new QueryArgument<ActivityCompanyInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ActivityCompany>("obj");
          return contextServiceLocator.Repository.UpDate<ActivityCompany>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ActivityCompany

      Field<StringGraphType>(
        "deleteActivityCompany",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ActivityCompany", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ActividadeEmpresa #############################################3

      #region Add dados de PersonType

      Field<PersonTypeType>(
        "addPersonType",
        arguments: new QueryArguments(
          new QueryArgument<PersonTypeInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<PersonType>("obj");
          return contextServiceLocator.Repository.Add<PersonType>(models);
        }
      );

      #endregion;

      #region Update Date de dados  PersonType

      Field<PersonTypeType>(
        "updatePersonType",
        arguments: new QueryArguments(
          new QueryArgument<PersonTypeInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<PersonType>("obj");
          return contextServiceLocator.Repository.UpDate<PersonType>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  PersonType

      Field<StringGraphType>(
        "deletePersonType",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("PersonType", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela PersonType #############################################3

      #region Add dados de Person

      Field<PersonsType>(
        "addPersons",
        arguments: new QueryArguments(
          new QueryArgument<PersonsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Persons>("obj");
          return contextServiceLocator.Repository.Add<Persons>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Person

      Field<PersonsType>(
        "updatePersons",
        arguments: new QueryArguments(
          new QueryArgument<PersonsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Persons>("obj");
          return contextServiceLocator.Repository.UpDate<Persons>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Person

      Field<StringGraphType>(
        "deletePersons",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Person", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Person #############################################3

      #region Add dados de Canal

      Field<CanalType>(
        "addCanal",
        arguments: new QueryArguments(
          new QueryArgument<CanalInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Canal>("obj");
          return contextServiceLocator.Repository.Add<Canal>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Canal

      Field<CanalType>(
        "updateCanal",
        arguments: new QueryArguments(
          new QueryArgument<CanalInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Canal>("obj");
          return contextServiceLocator.Repository.UpDate<Canal>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Canal

      Field<StringGraphType>(
        "deleteCanal",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Canal", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Canal #############################################3

      #region Add dados de RoutesCanal

      Field<ListGraphType<RoutesCanalType>>(
        "addRoutesCanal",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RoutesCanalInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<RoutesCanal>>("obj");
          foreach (var item in models)
          {
            contextServiceLocator.Repository.Add<RoutesCanal>(item);
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  RoutesCanal

      Field<RoutesCanalType>(
        "updateRoutesCanal",
        arguments: new QueryArguments(
          new QueryArgument<RoutesCanalInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RoutesCanal>("obj");
          return contextServiceLocator.Repository.UpDate<RoutesCanal>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RoutesCanal

      Field<ListGraphType<StringGraphType>>(
        "deleteRoutesCanal",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<StringGraphType>> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<List<string>>("id");
          foreach (var item in id)
          {
            contextServiceLocator.Repository.Delete("RoutesCanal", item);
          }
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RoutesCanal #############################################3

      #region Add dados de UserProfile

      Field<UserProfileType>(
        "addUserProfile",
        arguments: new QueryArguments(
          new QueryArgument<UserProfileInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<UserProfile>("obj");
          return contextServiceLocator.Repository.Add<UserProfile>(models);
        }
      );

      #endregion;

      #region Update Date de dados  UserProfile

      Field<UserProfileType>(
        "updateUserProfile",
        arguments: new QueryArguments(
          new QueryArgument<UserProfileInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<UserProfile>("obj");
          return contextServiceLocator.Repository.UpDate<UserProfile>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  UserProfile

      Field<StringGraphType>(
        "deleteUserProfile",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("UserProfile", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela UserProfile #############################################3

      #region Add dados de TypeReturns

      Field<TypeReturnsType>(
        "addTypeReturns",
        arguments: new QueryArguments(
          new QueryArgument<TypeReturnsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<TypeReturns>("obj");
          return contextServiceLocator.Repository.Add<TypeReturns>(models);
        }
      );

      #endregion;

      #region Update Date de dados  TypeReturns

      Field<TypeReturnsType>(
        "updateTypeReturns",
        arguments: new QueryArguments(
          new QueryArgument<TypeReturnsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<TypeReturns>("obj");
          return contextServiceLocator.Repository.UpDate<TypeReturns>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  TypeReturns

      Field<StringGraphType>(
        "deleteTypeReturns",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("TypeReturns", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela TypeReturns #############################################3

      #region Add dados de ServiceEmail

      Field<ServiceEmailType>(
        "addServiceEmail",
        arguments: new QueryArguments(
          new QueryArgument<ServiceEmailInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ServiceEmail>("obj");
          return contextServiceLocator.Repository.Add<ServiceEmail>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ServiceEmail

      Field<ServiceEmailType>(
        "updateServiceEmail",
        arguments: new QueryArguments(
          new QueryArgument<ServiceEmailInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ServiceEmail>("obj");
          return contextServiceLocator.Repository.UpDate<ServiceEmail>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ServiceEmail

      Field<StringGraphType>(
        "deleteServiceEmail",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ServiceEmail", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ServiceEmail #############################################3

      #region Add dados de SpecialRoutes

      Field<SpecialRoutesType>(
        "addSpecialRoutes",
        arguments: new QueryArguments(
          new QueryArgument<SpecialRoutesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<SpecialRoutes>("obj");
          return contextServiceLocator.Repository.Add<SpecialRoutes>(models);
        }
      );

      #endregion;

      #region Update Date de dados  SpecialRoutes

      Field<SpecialRoutesType>(
        "updateSpecialRoutes",
        arguments: new QueryArguments(
          new QueryArgument<SpecialRoutesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SpecialRoutes>("obj");
          return contextServiceLocator.Repository.UpDate<SpecialRoutes>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SpecialRoutes

      Field<StringGraphType>(
        "deleteSpecialRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SpecialRoutes", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SpecialRoutes #############################################3

      #region Add dados de SpecialRoutesRelationship

      Field<SpecialRoutesRelationshipType>(
        "addSpecialRoutesRelationship",
        arguments: new QueryArguments(
          new QueryArgument<SpecialRoutesRelationshipInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<SpecialRoutesRelationship>("obj");
          return contextServiceLocator.Repository.Add<SpecialRoutesRelationship>(models);
        }
      );

      #endregion;

      #region Update Date de dados  SpecialRoutesRelationship

      Field<SpecialRoutesRelationshipType>(
        "updateSpecialRoutesRelationship",
        arguments: new QueryArguments(
          new QueryArgument<SpecialRoutesRelationshipInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SpecialRoutesRelationship>("obj");
          return contextServiceLocator.Repository.UpDate<SpecialRoutesRelationship>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SpecialRoutesRelationship

      Field<StringGraphType>(
        "deleteSpecialRoutesRelationship",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SpecialRoutesRelationship", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SpecialRoutesRelationship #############################################3

      #region Add dados de PerfilMembers

      Field<PerfilMembersType>(
        "addPerfilMembers",
        arguments: new QueryArguments(
          new QueryArgument<PerfilMembersInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<PerfilMembers>("obj");

          var PerfilMembers = contextServiceLocator.Repository.Add<PerfilMembers>(models);

          foreach (var item in models.ProfileMenu)
          {
            item.PerfilMembersId = PerfilMembers.Id;
            var retornoProfileMenu = contextServiceLocator.Repository.Add<ProfileMenu>(item);

            foreach (var obj in item.ProfileMenuMethods)
            {
              obj.ProfileMenuId = retornoProfileMenu.Id;
              contextServiceLocator.Repository.Add<ProfileMenuMethods>(obj);
            }
          }
          models.PerfilClient.PerfilMembersId = PerfilMembers.Id;
          var perfilcliente = contextServiceLocator.Repository.Add<PerfilClient>(models.PerfilClient);

          return PerfilMembers;
        }
      );

      #endregion;

      #region Update Date de dados  PerfilMembers

      Field<PerfilMembersType>(
        "updatePerfilMembers",
        arguments: new QueryArguments(
          new QueryArgument<PerfilMembersInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<PerfilMembers>("obj");
          return contextServiceLocator.Repository.UpDate<PerfilMembers>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  PerfilMembers

      Field<StringGraphType>(
        "deletePerfilMembers",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("PerfilMembers", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela PerfilMembers #############################################3

      #region Add dados de Menu

      Field<MenuType>(
        "addMenu",
        arguments: new QueryArguments(
          new QueryArgument<MenuInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Menu>("obj");
          return contextServiceLocator.Repository.Add<Menu>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Menu

      Field<MenuType>(
        "updateMenu",
        arguments: new QueryArguments(
          new QueryArgument<MenuInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Menu>("obj");
          return contextServiceLocator.Repository.UpDate<Menu>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Menu

      Field<StringGraphType>(
        "deleteMenu",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Menu", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Menu #############################################3

      #region Add dados de MenuMethod

      Field<MenuMethodType>(
        "addMenuMethod",
        arguments: new QueryArguments(
          new QueryArgument<MenuMethodInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MenuMethod>("obj");
          return contextServiceLocator.Repository.Add<MenuMethod>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MenuMethod

      Field<MenuMethodType>(
        "updateMenuMethod",
        arguments: new QueryArguments(
          new QueryArgument<MenuMethodInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MenuMethod>("obj");
          return contextServiceLocator.Repository.UpDate<MenuMethod>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MenuMethod

      Field<StringGraphType>(
        "deleteMenuMethod",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MenuMethod", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MenuMethod #############################################3

      #region Add dados de MenuPerfil

      Field<MenuPerfilType>(
        "addMenuPerfil",
        arguments: new QueryArguments(
          new QueryArgument<MenuPerfilInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<MenuPerfil>("obj");
          return contextServiceLocator.Repository.Add<MenuPerfil>(models);
        }
      );

      #endregion;

      #region Update Date de dados  MenuPerfil

      Field<MenuPerfilType>(
        "updateMenuPerfil",
        arguments: new QueryArguments(
          new QueryArgument<MenuPerfilInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<MenuPerfil>("obj");
          return contextServiceLocator.Repository.UpDate<MenuPerfil>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  MenuPerfil

      Field<StringGraphType>(
        "deleteMenuPerfil",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("MenuPerfil", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela MenuPerfil #############################################3

      #region Add dados de PerfilClient

      Field<PerfilClientType>(
        "addPerfilClient",
        arguments: new QueryArguments(
          new QueryArgument<PerfilClientInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<PerfilClient>("obj");
          var PerfilClient = contextServiceLocator.Repository.Add<PerfilClient>(models);
          return PerfilClient;
        }
      );

      #endregion;

      #region Update Date de dados  PerfilClient

      Field<PerfilClientType>(
        "updatePerfilClient",
        arguments: new QueryArguments(
          new QueryArgument<PerfilClientInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<PerfilClient>("obj");
          return contextServiceLocator.Repository.UpDate<PerfilClient>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  PerfilClient

      Field<StringGraphType>(
        "deletePerfilClient",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("PerfilClient", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela PerfilClient #############################################3

      #region Add dados de ProfileMenu

      Field<ProfileMenuType>(
        "addProfileMenu",
        arguments: new QueryArguments(
          new QueryArgument<ProfileMenuInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ProfileMenu>("obj");
          return contextServiceLocator.Repository.Add<ProfileMenu>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ProfileMenu

      Field<ProfileMenuType>(
        "updateProfileMenu",
        arguments: new QueryArguments(
          new QueryArgument<ProfileMenuInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ProfileMenu>("obj");
          return contextServiceLocator.Repository.UpDate<ProfileMenu>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ProfileMenu

      Field<StringGraphType>(
        "deleteProfileMenu",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ProfileMenu", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ProfileMenu #############################################3

      #region Add dados de ProfileMenuMethods

      Field<ProfileMenuMethodsType>(
        "addProfileMenuMethods",
        arguments: new QueryArguments(
          new QueryArgument<ProfileMenuMethodsInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<ProfileMenuMethods>("obj");
          return contextServiceLocator.Repository.Add<ProfileMenuMethods>(models);
        }
      );

      #endregion;

      #region Update Date de dados  ProfileMenuMethods

      Field<ProfileMenuMethodsType>(
        "updateProfileMenuMethods",
        arguments: new QueryArguments(
          new QueryArgument<ProfileMenuMethodsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<ProfileMenuMethods>("obj");
          return contextServiceLocator.Repository.UpDate<ProfileMenuMethods>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  ProfileMenuMethods

      Field<StringGraphType>(
        "deleteProfileMenuMethods",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("ProfileMenuMethods", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela ProfileMenuMethods #############################################3

      #region Delete Date de dados  Status

      Field<StringGraphType>(
        "deleteStatuss",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Status", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Status #############################################3

      #region Add dados de Statuss

      Field<StatussType>(
        "addStatuss",
        arguments: new QueryArguments(
          new QueryArgument<StatussInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Statuss>("obj");
          return contextServiceLocator.Repository.Add<Statuss>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Statuss

      Field<StatussType>(
        "updateStatuss",
        arguments: new QueryArguments(
          new QueryArgument<StatussInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Statuss>("obj");
          return contextServiceLocator.Repository.UpDate<Statuss>(model, id);
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Statuss #############################################3

      #region Add dados de Continent

      Field<ContinentType>(
        "addContinent",
        arguments: new QueryArguments(
          new QueryArgument<ContinentInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Continent>("obj");
          return contextServiceLocator.Repository.Add<Continent>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Continent

      Field<ContinentType>(
        "updateContinent",
        arguments: new QueryArguments(
          new QueryArgument<ContinentInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Continent>("obj");
          return contextServiceLocator.Repository.UpDate<Continent>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Continent

      Field<StringGraphType>(
        "deleteContinent",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Continent", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Continent #############################################3

      #region Add dados de Region

      Field<RegionType>(
        "addRegion",
        arguments: new QueryArguments(
          new QueryArgument<RegionInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Region>("obj");
          return contextServiceLocator.Repository.Add<Region>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Region

      Field<RegionType>(
        "updateRegion",
        arguments: new QueryArguments(
          new QueryArgument<RegionInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Region>("obj");
          return contextServiceLocator.Repository.UpDate<Region>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Region

      Field<StringGraphType>(
        "deleteRegion",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Region", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Region #############################################3

      #region Add dados de Country

      Field<CountryType>(
        "addCountry",
        arguments: new QueryArguments(
          new QueryArgument<CountryInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Country>("obj");
          return contextServiceLocator.Repository.Add<Country>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Country

      Field<CountryType>(
        "updateCountry",
        arguments: new QueryArguments(
          new QueryArgument<CountryInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Country>("obj");
          return contextServiceLocator.Repository.UpDate<Country>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Country

      Field<StringGraphType>(
        "deleteCountry",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Country", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Country #############################################3

      #region Add dados de Province

      Field<ProvinceType>(
        "addProvince",
        arguments: new QueryArguments(
          new QueryArgument<ProvinceInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Province>("obj");
          return contextServiceLocator.Repository.Add<Province>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Province

      Field<ProvinceType>(
        "updateProvince",
        arguments: new QueryArguments(
          new QueryArgument<ProvinceInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Province>("obj");
          return contextServiceLocator.Repository.UpDate<Province>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Province

      Field<StringGraphType>(
        "deleteProvince",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Province", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Province #############################################3

      #region Add dados de County

      Field<CountyType>(
        "addCounty",
        arguments: new QueryArguments(
          new QueryArgument<CountyInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<County>("obj");
          return contextServiceLocator.Repository.Add<County>(models);
        }
      );

      #endregion;

      #region Update Date de dados  County

      Field<CountyType>(
        "updateCounty",
        arguments: new QueryArguments(
          new QueryArgument<CountyInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<County>("obj");
          return contextServiceLocator.Repository.UpDate<County>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  County

      Field<StringGraphType>(
        "deleteCounty",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("County", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela County #############################################3

      #region Add dados de District

      Field<DistrictType>(
        "addDistrict",
        arguments: new QueryArguments(
          new QueryArgument<DistrictInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<District>("obj");
          return contextServiceLocator.Repository.Add<District>(models);
        }
      );

      #endregion;

      #region Update Date de dados  District

      Field<DistrictType>(
        "updateDistrict",
        arguments: new QueryArguments(
          new QueryArgument<DistrictInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<District>("obj");
          return contextServiceLocator.Repository.UpDate<District>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  District

      Field<StringGraphType>(
        "deleteDistrict",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("District", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela District #############################################3

      #region Add dados de Neighborhood

      Field<NeighborhoodType>(
        "addNeighborhood",
        arguments: new QueryArguments(
          new QueryArgument<NeighborhoodInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Neighborhood>("obj");
          return contextServiceLocator.Repository.Add<Neighborhood>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Neighborhood

      Field<NeighborhoodType>(
        "updateNeighborhood",
        arguments: new QueryArguments(
          new QueryArgument<NeighborhoodInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Neighborhood>("obj");
          return contextServiceLocator.Repository.UpDate<Neighborhood>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Neighborhood

      Field<StringGraphType>(
        "deleteNeighborhood",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Neighborhood", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Neighborhood #############################################3

      #region Add dados de Street

      Field<StreetType>(
        "addStreet",
        arguments: new QueryArguments(
          new QueryArgument<StreetInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<Street>("obj");
          return contextServiceLocator.Repository.Add<Street>(models);
        }
      );

      #endregion;

      #region Update Date de dados  Street

      Field<StreetType>(
        "updateStreet",
        arguments: new QueryArguments(
          new QueryArgument<StreetInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<Street>("obj");
          return contextServiceLocator.Repository.UpDate<Street>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  Street

      Field<StringGraphType>(
        "deleteStreet",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("Street", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela Street #############################################3

      #region Add dados de City

      Field<CityType>(
        "addCity",
        arguments: new QueryArguments(
          new QueryArgument<CityInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<City>("obj");
          return contextServiceLocator.Repository.Add<City>(models);
        }
      );

      #endregion;

      #region Update Date de dados  City

      Field<CityType>(
        "updateCity",
        arguments: new QueryArguments(
          new QueryArgument<CityInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<City>("obj");
          return contextServiceLocator.Repository.UpDate<City>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  City

      Field<StringGraphType>(
        "deleteCity",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("City", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela City #############################################3

      #region Add dados de RoutesCountries

      Field<ListGraphType<RoutesCountriesType>>(
        "addRoutesCountries",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RoutesCountriesInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<RoutesCountries>>("obj");

          foreach (var obj in models)
          {
            var dados = contextServiceLocator.Repository.Add<RoutesCountries>(obj);

            if (obj.SelectedProvinces != null)
            {
              foreach (var item in obj.SelectedProvinces)
              {
                item.RoutesCountriesId = dados.Id;
                contextServiceLocator.Repository.Add<SelectedProvinces>(item);
              }
            }
          }
          return models;
        }
      );

      #endregion;

      #region Update Date de dados  RoutesCountries

      Field<RoutesCountriesType>(
        "updateRoutesCountries",
        arguments: new QueryArguments(
          new QueryArgument<RoutesCountriesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RoutesCountries>("obj");
          return contextServiceLocator.Repository.UpDate<RoutesCountries>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RoutesCountries

      Field<StringGraphType>(
        "deleteRoutesCountries",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("RoutesCountries", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RoutesCountries #############################################3

      #region Add dados de SelectedProvinces

      Field<SelectedProvincesType>(
        "addSelectedProvinces",
        arguments: new QueryArguments(
          new QueryArgument<SelectedProvincesInputType> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<SelectedProvinces>("obj");
          return contextServiceLocator.Repository.Add<SelectedProvinces>(models);
        }
      );

      #endregion;

      #region Update Date de dados  SelectedProvinces

      Field<SelectedProvincesType>(
        "updateSelectedProvinces",
        arguments: new QueryArguments(
          new QueryArgument<SelectedProvincesInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<SelectedProvinces>("obj");
          return contextServiceLocator.Repository.UpDate<SelectedProvinces>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  SelectedProvinces

      Field<StringGraphType>(
        "deleteSelectedProvinces",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("SelectedProvinces", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela SelectedProvinces #############################################3

      #region Add dados de RouteAnalytics

      Field<ListGraphType<RouteAnalyticsType>>(
        "addGraficAnalytics",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<RouteAnalyticsInputType>> { Name = "obj" }
        ),
        resolve: context =>
        {
          var models = context.GetArgument<List<RouteAnalytics>>("obj");

          int[] vetor = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


          foreach (var colecao in models)
          {
            if (colecao.ClientClients == null)
            {
              var dados = contextServiceLocator.Repository.selectOne<RouteAnalytics>(colecao, colecao.RouteId);


              var dadoss = new List<RouteAnalytics>();

              foreach (var item in vetor)
              {
                if (colecao.Date == "" || colecao.Date == null)
                  colecao.Date = "0";
                var valor = new Connect().executeAd<RouteAnalytics>($"exec sp_RouteAnalytics {item},{colecao.Date},'{colecao.RouteId}','{colecao.CanalId}','{colecao.MethodId}'");
                valor.ElementAt(0).Date = colecao.Date + "-" + item;
                dadoss.AddRange(valor.ToList());
              }
              models = dadoss;
              //models.statisticsbycategory = alguma;
            }
            else
            {
              if (colecao.ClientClients.statisticsClientClient == null)
              {
                var dadoscliente = new statisticsClientClient();

                foreach (var item in contextServiceLocator.Repository.selectOne<ClientClients>(colecao.ClientClients, colecao.ClientClients.ClientId))
                {
                  dadoscliente.TotalCustomer++;
                  if (item.IsActive == true)
                    dadoscliente.Totalactivecustomers++;
                  if (item.IsActive == false)
                    dadoscliente.Totalinactivecustomers++;
                }
                
                models.ElementAt(0).statisticsClientClient.Add(dadoscliente);
                
                //colecao.statisticsClientClient.Add(dadoscliente);
                //models.statisticsClientClient=models.statisticsClientClient.Distinct();
              }
              else
              {
                var ano = colecao.ClientClients.statisticsClientClient;
                var dadoss = new List<statisticsClientClient>();
                foreach (var item in vetor)
                {
                  var valor = new Connect().executeAd<statisticsClientClient>($"EXEC sp_Statistic_ClientClients {item},{ano.year}");
                  valor.ElementAt(0).month = item;
                  dadoss.AddRange(valor.ToList());
                }
                for (int i = 0; i < models.Count; i++)
                {
                  models.ElementAt(i).statisticsClientClient = dadoss;
                }

              }
            }

          }

          return models.Distinct().ToList();
        }
      );

      #endregion;

      #region Update Date de dados  RouteAnalytics

      Field<RouteAnalyticsType>(
        "updateRouteAnalytics",
        arguments: new QueryArguments(
          new QueryArgument<RouteAnalyticsInputType> { Name = "obj" },
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");

          var model = context.GetArgument<RouteAnalytics>("obj");
          return contextServiceLocator.Repository.UpDate<RouteAnalytics>(model, id);
        }
      );

      #endregion;

      #region Delete Date de dados  RouteAnalytics

      Field<StringGraphType>(
        "deleteRouteAnalytics",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" }
        ),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          contextServiceLocator.Repository.Delete("RouteAnalytics", id);
          return "Deletado com sucesso";
        }
      );

      #endregion;

      //######################################## Fim do crud da tabela RouteAnalytics #############################################3

      

#region Add dados de MetricTypes

 Field<MetricTypesType>(
    "addMetricTypes",
    arguments : new QueryArguments(
    new QueryArgument<MetricTypesInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<MetricTypes>("obj");
        return contextServiceLocator.Repository.Add<MetricTypes>(models);
    }
  );

#endregion;

#region Update Date de dados  MetricTypes

  Field<MetricTypesType>(
      "updateMetricTypes",
      arguments: new QueryArguments (
      new QueryArgument<MetricTypesInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<MetricTypes>("obj");
            return contextServiceLocator.Repository.UpDate<MetricTypes>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  MetricTypes

Field<StringGraphType>(
  "deleteMetricTypes",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("MetricTypes", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela MetricTypes #############################################3



#region Add dados de IntervalUnits

 Field<IntervalUnitsType>(
    "addIntervalUnits",
    arguments : new QueryArguments(
    new QueryArgument<IntervalUnitsInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<IntervalUnits>("obj");
        return contextServiceLocator.Repository.Add<IntervalUnits>(models);
    }
  );

#endregion;

#region Update Date de dados  IntervalUnits

  Field<IntervalUnitsType>(
      "updateIntervalUnits",
      arguments: new QueryArguments (
      new QueryArgument<IntervalUnitsInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<IntervalUnits>("obj");
            return contextServiceLocator.Repository.UpDate<IntervalUnits>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  IntervalUnits

Field<StringGraphType>(
  "deleteIntervalUnits",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("IntervalUnits", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela IntervalUnits #############################################3



#region Add dados de Alerts

 Field<AlertsType>(
    "addAlerts",
    arguments : new QueryArguments(
    new QueryArgument<AlertsInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Alerts>("obj");
        return contextServiceLocator.Repository.Add<Alerts>(models);
    }
  );

#endregion;

#region Update Date de dados  Alerts

  Field<AlertsType>(
      "updateAlerts",
      arguments: new QueryArguments (
      new QueryArgument<AlertsInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Alerts>("obj");
            return contextServiceLocator.Repository.UpDate<Alerts>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Alerts

Field<StringGraphType>(
  "deleteAlerts",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Alerts", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Alerts #############################################3



#region Add dados de StatusCode

 Field<StatusCodeType>(
    "addStatusCode",
    arguments : new QueryArguments(
    new QueryArgument<StatusCodeInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<StatusCode>("obj");
        return contextServiceLocator.Repository.Add<StatusCode>(models);
    }
  );

#endregion;

#region Update Date de dados  StatusCode

  Field<StatusCodeType>(
      "updateStatusCode",
      arguments: new QueryArguments (
      new QueryArgument<StatusCodeInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<StatusCode>("obj");
            return contextServiceLocator.Repository.UpDate<StatusCode>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  StatusCode

Field<StringGraphType>(
  "deleteStatusCode",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("StatusCode", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela StatusCode #############################################3



#region Add dados de StatusCodeAlert

 Field<StatusCodeAlertType>(
    "addStatusCodeAlert",
    arguments : new QueryArguments(
    new QueryArgument<StatusCodeAlertInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<StatusCodeAlert>("obj");
        return contextServiceLocator.Repository.Add<StatusCodeAlert>(models);
    }
  );

#endregion;

#region Update Date de dados  StatusCodeAlert

  Field<StatusCodeAlertType>(
      "updateStatusCodeAlert",
      arguments: new QueryArguments (
      new QueryArgument<StatusCodeAlertInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<StatusCodeAlert>("obj");
            return contextServiceLocator.Repository.UpDate<StatusCodeAlert>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  StatusCodeAlert

Field<StringGraphType>(
  "deleteStatusCodeAlert",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("StatusCodeAlert", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela StatusCodeAlert #############################################3



#region Add dados de ThrottleInterval

 Field<ThrottleIntervalType>(
    "addThrottleInterval",
    arguments : new QueryArguments(
    new QueryArgument<ThrottleIntervalInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<ThrottleInterval>("obj");
        return contextServiceLocator.Repository.Add<ThrottleInterval>(models);
    }
  );

#endregion;

#region Update Date de dados  ThrottleInterval

  Field<ThrottleIntervalType>(
      "updateThrottleInterval",
      arguments: new QueryArguments (
      new QueryArgument<ThrottleIntervalInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<ThrottleInterval>("obj");
            return contextServiceLocator.Repository.UpDate<ThrottleInterval>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  ThrottleInterval

Field<StringGraphType>(
  "deleteThrottleInterval",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("ThrottleInterval", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela ThrottleInterval #############################################3



#region Add dados de MetricConditions

 Field<MetricConditionsType>(
    "addMetricConditions",
    arguments : new QueryArguments(
    new QueryArgument<MetricConditionsInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<MetricConditions>("obj");
        return contextServiceLocator.Repository.Add<MetricConditions>(models);
    }
  );

#endregion;

#region Update Date de dados  MetricConditions

  Field<MetricConditionsType>(
      "updateMetricConditions",
      arguments: new QueryArguments (
      new QueryArgument<MetricConditionsInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<MetricConditions>("obj");
            return contextServiceLocator.Repository.UpDate<MetricConditions>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  MetricConditions

Field<StringGraphType>(
  "deleteMetricConditions",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("MetricConditions", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela MetricConditions #############################################3



#region Add dados de TypeAlert

 Field<TypeAlertType>(
    "addTypeAlert",
    arguments : new QueryArguments(
    new QueryArgument<TypeAlertInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<TypeAlert>("obj");
        return contextServiceLocator.Repository.Add<TypeAlert>(models);
    }
  );

#endregion;

#region Update Date de dados  TypeAlert

  Field<TypeAlertType>(
      "updateTypeAlert",
      arguments: new QueryArguments (
      new QueryArgument<TypeAlertInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<TypeAlert>("obj");
            return contextServiceLocator.Repository.UpDate<TypeAlert>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  TypeAlert

Field<StringGraphType>(
  "deleteTypeAlert",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("TypeAlert", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela TypeAlert #############################################3



#region Add dados de Documentation

 Field<DocumentationType>(
    "addDocumentation",
    arguments : new QueryArguments(
    new QueryArgument<DocumentationInputType> {Name="obj"}
    ),
    resolve :context =>
    {
      var models = context.GetArgument<Documentation>("obj");
      return contextServiceLocator.Repository.Add<Documentation>(models);
    }
  );

#endregion;

#region Update Date de dados  Documentation

  Field<DocumentationType>(
      "updateDocumentation",
      arguments: new QueryArguments (
      new QueryArgument<DocumentationInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Documentation>("obj");
            return contextServiceLocator.Repository.UpDate<Documentation>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Documentation

Field<StringGraphType>(
  "deleteDocumentation",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Documentation", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Documentation #############################################3



#region Add dados de Plugin

 FieldAsync<PluginType>(
    "addPlugin",
    arguments : new QueryArguments(
    new QueryArgument<PluginInputType> {Name="obj"}
    ),
    resolve :async context =>
    {
      var models = context.GetArgument<Plugin>("obj");

      var dados = contextServiceLocator.Repository.Add<Plugin>(models);
      models.PluginConfig.PluginId = dados.Id;
      contextServiceLocator.Repository.Add<PluginConfig>(models.PluginConfig);
      
      return dados;
    }
  );

#endregion;

#region Update Date de dados  Plugin

  Field<PluginType>(
      "updatePlugin",
      arguments: new QueryArguments (
      new QueryArgument<PluginInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Plugin>("obj");
            return contextServiceLocator.Repository.UpDate<Plugin>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Plugin

Field<StringGraphType>(
  "deletePlugin",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Plugin", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Plugin #############################################3



#region Add dados de PluginConfig

 Field<PluginConfigType>(
    "addPluginConfig",
    arguments : new QueryArguments(
    new QueryArgument<PluginConfigInputType> {Name="obj"}
    ),
    resolve :context =>
    {
      var models = context.GetArgument<PluginConfig>("obj");
      return contextServiceLocator.Repository.Add<PluginConfig>(models);
    }
  );

#endregion;

#region Update Date de dados  PluginConfig

  Field<PluginConfigType>(
      "updatePluginConfig",
      arguments: new QueryArguments (
      new QueryArgument<PluginConfigInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<PluginConfig>("obj");
            return contextServiceLocator.Repository.UpDate<PluginConfig>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  PluginConfig

Field<StringGraphType>(
  "deletePluginConfig",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("PluginConfig", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela PluginConfig #############################################3



#region Add dados de Datasheet

 Field<DatasheetType>(
    "addDatasheet",
    arguments : new QueryArguments(
    new QueryArgument<DatasheetInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Datasheet>("obj");
        return contextServiceLocator.Repository.Add<Datasheet>(models);
    }
  );

#endregion;

#region Update Date de dados  Datasheet

  Field<DatasheetType>(
      "updateDatasheet",
      arguments: new QueryArguments (
      new QueryArgument<DatasheetInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Datasheet>("obj");
            return contextServiceLocator.Repository.UpDate<Datasheet>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Datasheet

Field<StringGraphType>(
  "deleteDatasheet",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Datasheet", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Datasheet #############################################3



#region Add dados de Distribution

 Field<DistributionType>(
    "addDistribution",
    arguments : new QueryArguments(
    new QueryArgument<DistributionInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Distribution>("obj");
        return contextServiceLocator.Repository.Add<Distribution>(models);
    }
  );

#endregion;

#region Update Date de dados  Distribution

  Field<DistributionType>(
      "updateDistribution",
      arguments: new QueryArguments (
      new QueryArgument<DistributionInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Distribution>("obj");
            return contextServiceLocator.Repository.UpDate<Distribution>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Distribution

Field<StringGraphType>(
  "deleteDistribution",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Distribution", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Distribution #############################################3

#region Add dados de Error

 Field<ErrorType>(
    "addError",
    arguments : new QueryArguments(
    new QueryArgument<ErrorInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Error>("obj");
        return contextServiceLocator.Repository.Add<Error>(models);
    }
  );

#endregion;

#region Update Date de dados  Error

  Field<ErrorType>(
      "updateError",
      arguments: new QueryArguments (
      new QueryArgument<ErrorInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Error>("obj");
            return contextServiceLocator.Repository.UpDate<Error>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Error

Field<StringGraphType>(
  "deleteError",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Error", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Error #############################################3

#region Add dados de Indice

 Field<IndiceType>(
    "addIndice",
    arguments : new QueryArguments(
    new QueryArgument<IndiceInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Indice>("obj");
        return contextServiceLocator.Repository.Add<Indice>(models);
    }
  );

#endregion;

#region Update Date de dados  Indice

  Field<IndiceType>(
      "updateIndice",
      arguments: new QueryArguments (
      new QueryArgument<IndiceInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Indice>("obj");
            return contextServiceLocator.Repository.UpDate<Indice>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Indice

Field<StringGraphType>(
  "deleteIndice",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Indice", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Indice #############################################3



#region Add dados de Item

 Field<ItemType>(
    "addItem",
    arguments : new QueryArguments(
    new QueryArgument<ItemInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Item>("obj");
        return contextServiceLocator.Repository.Add<Item>(models);
    }
  );

#endregion;

#region Update Date de dados  Item

  Field<ItemType>(
      "updateItem",
      arguments: new QueryArguments (
      new QueryArgument<ItemInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Item>("obj");
            return contextServiceLocator.Repository.UpDate<Item>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Item

Field<StringGraphType>(
  "deleteItem",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Item", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Item #############################################3



#region Add dados de Work

 Field<WorkType>(
    "addWork",
    arguments : new QueryArguments(
    new QueryArgument<WorkInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Work>("obj");
        return contextServiceLocator.Repository.Add<Work>(models);
    }
  );

#endregion;

#region Update Date de dados  Work

  Field<WorkType>(
      "updateWork",
      arguments: new QueryArguments (
      new QueryArgument<WorkInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Work>("obj");
            return contextServiceLocator.Repository.UpDate<Work>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Work

Field<StringGraphType>(
  "deleteWork",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Work", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Work #############################################3



#region Add dados de Url

 Field<UrlType>(
    "addUrl",
    arguments : new QueryArguments(
    new QueryArgument<UrlInputType> {Name="obj"}
    ),
    resolve :context =>
    {
        var models = context.GetArgument<Url>("obj");
        return contextServiceLocator.Repository.Add<Url>(models);
    }
  );

#endregion;

#region Update Date de dados  Url

  Field<UrlType>(
      "updateUrl",
      arguments: new QueryArguments (
      new QueryArgument<UrlInputType> {Name="obj"},
      new QueryArgument<StringGraphType>{Name ="id"}
          ),
          resolve : context =>
          {
            var id =context.GetArgument<string>("id");
                   
            var model =context.GetArgument<Url>("obj");
            return contextServiceLocator.Repository.UpDate<Url>(model, id);
          }
    );

#endregion;


#region Delete Date de dados  Url

Field<StringGraphType>(
  "deleteUrl",
    arguments : new QueryArguments(
    new QueryArgument<StringGraphType>{Name="id"}
  ),
  resolve: context =>
  {
    var id = context.GetArgument<string>("id");
    contextServiceLocator.Repository.Delete("Url", id);
    return "Deletado com sucesso";
  }
);

#endregion;

//######################################## Fim do crud da tabela Url #############################################3


//AppMutationFields



    }
  }
}











