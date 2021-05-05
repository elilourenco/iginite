using System.Collections.Generic;
using GraphQL.Types;
using libongo.Helpers;
using libongo.Models;
using libongo.plugin;
using libongo.Type;
using Newtonsoft.Json;

namespace libongo.GraphiQl.Config
{
  public class Query : ObjectGraphType
  {
    public Query(ContextServiceLocator contextServiceLocator)
    {


      Field<StringGraphType>(
        "generationDb",
        arguments: new QueryArguments(
          new QueryArgument<ListGraphType<StringGraphType>> { Name = "tabela" }
        ),
        resolve: context =>
        {
          var tabela = context.GetArgument<List<string>>("tabela");
          foreach (var obj in tabela)
            new ReadFile().GerarModelsTable(obj);
          return "";
        }
      );

      //######################################## Fim da listagem da tabela EFMigrationsHistory #############################################3

      #region pesquisar dados de ApiResourceClaims 

      Field<ListGraphType<ApiResourceClaimsType>>(
        "searchApiResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResourceClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResourceClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResourceClaims 

      Field<ListGraphType<ApiResourceClaimsType>>(
        "listApiResourceClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiResourceClaims>("ApiResourceClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResourceClaims #############################################3

      #region pesquisar dados de ApiResourceProperties 

      Field<ListGraphType<ApiResourcePropertiesType>>(
        "searchApiResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResourceProperties();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResourceProperties>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResourceProperties 

      Field<ListGraphType<ApiResourcePropertiesType>>(
        "listApiResourceProperties",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiResourceProperties>("ApiResourceProperties");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResourceProperties #############################################3

      #region pesquisar dados de ApiResources 

      Field<ListGraphType<ApiResourcesType>>(
        "searchApiResources",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResources();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResources>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResources 

      Field<ListGraphType<ApiResourcesType>>(
        "listApiResources",
        resolve: context =>
        {
          var dados = contextServiceLocator.Repository.select<ApiResources>("ApiResources");

          

          return dados;
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResources #############################################3

      #region pesquisar dados de ApiResourceScopes 

      Field<ListGraphType<ApiResourceScopesType>>(
        "searchApiResourceScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResourceScopes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResourceScopes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResourceScopes 

      Field<ListGraphType<ApiResourceScopesType>>(
        "listApiResourceScopes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiResourceScopes>("ApiResourceScopes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResourceScopes #############################################3

      #region pesquisar dados de ApiResourceSecrets 

      Field<ListGraphType<ApiResourceSecretsType>>(
        "searchApiResourceSecrets",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResourceSecrets();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResourceSecrets>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResourceSecrets 

      Field<ListGraphType<ApiResourceSecretsType>>(
        "listApiResourceSecrets",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiResourceSecrets>("ApiResourceSecrets");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResourceSecrets #############################################3

      #region pesquisar dados de ApiScopeClaims 

      Field<ListGraphType<ApiScopeClaimsType>>(
        "searchApiScopeClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiScopeClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiScopeClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiScopeClaims 

      Field<ListGraphType<ApiScopeClaimsType>>(
        "listApiScopeClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiScopeClaims>("ApiScopeClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiScopeClaims #############################################3

      #region pesquisar dados de ApiScopeProperties 

      Field<ListGraphType<ApiScopePropertiesType>>(
        "searchApiScopeProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiScopeProperties();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiScopeProperties>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiScopeProperties 

      Field<ListGraphType<ApiScopePropertiesType>>(
        "listApiScopeProperties",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiScopeProperties>("ApiScopeProperties");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiScopeProperties #############################################3

      #region pesquisar dados de ApiScopes 

      Field<ListGraphType<ApiScopesType>>(
        "searchApiScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiScopes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiScopes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiScopes 

      Field<ListGraphType<ApiScopesType>>(
        "listApiScopes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiScopes>("ApiScopes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiScopes #############################################3

      #region pesquisar dados de AspNetRoleClaims 

      Field<ListGraphType<AspNetRoleClaimsType>>(
        "searchAspNetRoleClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetRoleClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetRoleClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetRoleClaims 

      Field<ListGraphType<AspNetRoleClaimsType>>(
        "listAspNetRoleClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetRoleClaims>("AspNetRoleClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetRoleClaims #############################################3

      #region pesquisar dados de AspNetRoles 

      Field<ListGraphType<AspNetRolesType>>(
        "searchAspNetRoles",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetRoles();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetRoles>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetRoles 

      Field<ListGraphType<AspNetRolesType>>(
        "listAspNetRoles",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetRoles>("AspNetRoles");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetRoles #############################################3

      #region pesquisar dados de AspNetUserClaims 

      Field<ListGraphType<AspNetUserClaimsType>>(
        "searchAspNetUserClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetUserClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetUserClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetUserClaims 

      Field<ListGraphType<AspNetUserClaimsType>>(
        "listAspNetUserClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetUserClaims>("AspNetUserClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetUserClaims #############################################3

      #region pesquisar dados de AspNetUserRoles 

      Field<ListGraphType<AspNetUserRolesType>>(
        "searchAspNetUserRoles",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetUserRoles();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetUserRoles>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetUserRoles 

      Field<ListGraphType<AspNetUserRolesType>>(
        "listAspNetUserRoles",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetUserRoles>("AspNetUserRoles");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetUserRoles #############################################3

      #region pesquisar dados de AspNetUsers 

      Field<ListGraphType<AspNetUsersType>>(
        "searchAspNetUsers",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetUsers();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetUsers>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetUsers 

      Field<ListGraphType<AspNetUsersType>>(
        "listAspNetUsers",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetUsers>("AspNetUsers");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetUsers #############################################3

      #region pesquisar dados de AspNetUserTokens 

      Field<ListGraphType<AspNetUserTokensType>>(
        "searchAspNetUserTokens",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new AspNetUserTokens();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<AspNetUserTokens>(models, id);
        }
      );

      #endregion;

      #region Listar dados de AspNetUserTokens 

      Field<ListGraphType<AspNetUserTokensType>>(
        "listAspNetUserTokens",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<AspNetUserTokens>("AspNetUserTokens");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AspNetUserTokens #############################################3

      #region pesquisar dados de ClientClaims 

      Field<ListGraphType<ClientClaimsType>>(
        "searchClientClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientClaims 

      Field<ListGraphType<ClientClaimsType>>(
        "listClientClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientClaims>("ClientClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientClaims #############################################3

      #region pesquisar dados de ClientCorsOrigins 

      Field<ListGraphType<ClientCorsOriginsType>>(
        "searchClientCorsOrigins",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientCorsOrigins();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientCorsOrigins>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientCorsOrigins 

      Field<ListGraphType<ClientCorsOriginsType>>(
        "listClientCorsOrigins",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientCorsOrigins>("ClientCorsOrigins");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientCorsOrigins #############################################3

      #region pesquisar dados de ClientGrantTypes 

      Field<ListGraphType<ClientGrantTypesType>>(
        "searchClientGrantTypes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientGrantTypes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientGrantTypes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientGrantTypes 

      Field<ListGraphType<ClientGrantTypesType>>(
        "listClientGrantTypes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientGrantTypes>("ClientGrantTypes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientGrantTypes #############################################3

      #region pesquisar dados de ClientIdPRestrictions 

      Field<ListGraphType<ClientIdPRestrictionsType>>(
        "searchClientIdPRestrictions",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientIdPRestrictions();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientIdPRestrictions>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientIdPRestrictions 

      Field<ListGraphType<ClientIdPRestrictionsType>>(
        "listClientIdPRestrictions",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientIdPRestrictions>("ClientIdPRestrictions");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientIdPRestrictions #############################################3

      #region pesquisar dados de ClientPostLogoutRedirectUris 

      Field<ListGraphType<ClientPostLogoutRedirectUrisType>>(
        "searchClientPostLogoutRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientPostLogoutRedirectUris();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientPostLogoutRedirectUris>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientPostLogoutRedirectUris 

      Field<ListGraphType<ClientPostLogoutRedirectUrisType>>(
        "listClientPostLogoutRedirectUris",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientPostLogoutRedirectUris>("ClientPostLogoutRedirectUris");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientPostLogoutRedirectUris #############################################3

      #region pesquisar dados de ClientProperties 

      Field<ListGraphType<ClientPropertiesType>>(
        "searchClientProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientProperties();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientProperties>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientProperties 

      Field<ListGraphType<ClientPropertiesType>>(
        "listClientProperties",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientProperties>("ClientProperties");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientProperties #############################################3

      #region pesquisar dados de ClientRedirectUris 

      Field<ListGraphType<ClientRedirectUrisType>>(
        "searchClientRedirectUris",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientRedirectUris();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientRedirectUris>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientRedirectUris 

      Field<ListGraphType<ClientRedirectUrisType>>(
        "listClientRedirectUris",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientRedirectUris>("ClientRedirectUris");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientRedirectUris #############################################3

      #region pesquisar dados de Clients 

      Field<ListGraphType<ClientsType>>(
        "searchClients",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Clients();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Clients>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Clients 

      Field<ListGraphType<ClientsType>>(
        "listClients",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Clients>("Clients");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Clients #############################################3

      #region pesquisar dados de ClientScopes 

      Field<ListGraphType<ClientScopesType>>(
        "searchClientScopes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientScopes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientScopes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientScopes 

      Field<ListGraphType<ClientScopesType>>(
        "listClientScopes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientScopes>("ClientScopes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientScopes #############################################3

      #region pesquisar dados de ClientSecrets 

      Field<ListGraphType<ClientSecretsType>>(
        "searchClientSecrets",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientSecrets();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientSecrets>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientSecrets 

      Field<ListGraphType<ClientSecretsType>>(
        "listClientSecrets",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientSecrets>("ClientSecrets");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientSecrets #############################################3

      #region pesquisar dados de DeviceCodes 

      Field<ListGraphType<DeviceCodesType>>(
        "searchDeviceCodes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new DeviceCodes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<DeviceCodes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de DeviceCodes 

      Field<ListGraphType<DeviceCodesType>>(
        "listDeviceCodes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<DeviceCodes>("DeviceCodes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela DeviceCodes #############################################3

      #region pesquisar dados de IdentityResourceClaims 

      Field<ListGraphType<IdentityResourceClaimsType>>(
        "searchIdentityResourceClaims",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new IdentityResourceClaims();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<IdentityResourceClaims>(models, id);
        }
      );

      #endregion;

      #region Listar dados de IdentityResourceClaims 

      Field<ListGraphType<IdentityResourceClaimsType>>(
        "listIdentityResourceClaims",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<IdentityResourceClaims>("IdentityResourceClaims");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela IdentityResourceClaims #############################################3

      #region pesquisar dados de IdentityResourceProperties 

      Field<ListGraphType<IdentityResourcePropertiesType>>(
        "searchIdentityResourceProperties",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new IdentityResourceProperties();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<IdentityResourceProperties>(models, id);
        }
      );

      #endregion;

      #region Listar dados de IdentityResourceProperties 

      Field<ListGraphType<IdentityResourcePropertiesType>>(
        "listIdentityResourceProperties",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<IdentityResourceProperties>("IdentityResourceProperties");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela IdentityResourceProperties #############################################3

      #region pesquisar dados de IdentityResources 

      Field<ListGraphType<IdentityResourcesType>>(
        "searchIdentityResources",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new IdentityResources();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<IdentityResources>(models, id);
        }
      );

      #endregion;

      #region Listar dados de IdentityResources 

      Field<ListGraphType<IdentityResourcesType>>(
        "listIdentityResources",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<IdentityResources>("IdentityResources");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela IdentityResources #############################################3

      #region pesquisar dados de PersistedGrants 

      Field<ListGraphType<PersistedGrantsType>>(
        "searchPersistedGrants",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new PersistedGrants();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<PersistedGrants>(models, id);
        }
      );

      #endregion;

      #region Listar dados de PersistedGrants 

      Field<ListGraphType<PersistedGrantsType>>(
        "listPersistedGrants",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<PersistedGrants>("PersistedGrants");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela PersistedGrants #############################################3

      #region pesquisar dados de ClientClients 

      Field<ListGraphType<ClientClientsType>>(
        "searchClientClients",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientClients();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientClients>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientClients 

      Field<ListGraphType<ClientClientsType>>(
        "listClientClients",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientClients>("ClientClients");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientClients #############################################3

      #region pesquisar dados de ClientClientsRoutes 

      Field<ListGraphType<ClientClientsRoutesType>>(
        "searchClientClientsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ClientClientsRoutes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ClientClientsRoutes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ClientClientsRoutes 

      Field<ListGraphType<ClientClientsRoutesType>>(
        "listClientClientsRoutes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ClientClientsRoutes>("ClientClientsRoutes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ClientClientsRoutes #############################################3

      #region pesquisar dados de Protocols 

      Field<ListGraphType<ProtocolsType>>(
        "searchProtocols",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Protocols();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Protocols>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Protocols 

      Field<ListGraphType<ProtocolsType>>(
        "listProtocols",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Protocols>("Protocols");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Protocols #############################################3

      #region pesquisar dados de ApiResourcesTags 

      Field<ListGraphType<ApiResourcesTagsType>>(
        "searchApiResourcesTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new ApiResourcesTags();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<ApiResourcesTags>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ApiResourcesTags 

      Field<ListGraphType<ApiResourcesTagsType>>(
        "listApiResourcesTags",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<ApiResourcesTags>("ApiResourcesTags");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ApiResourcesTags #############################################3

      #region pesquisar dados de Paths 

      Field<ListGraphType<PathsType>>(
        "searchPaths",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Paths();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Paths>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Paths 

      Field<ListGraphType<PathsType>>(
        "listPaths",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Paths>("Paths");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Paths #############################################3

      #region pesquisar dados de Routes 

      Field<ListGraphType<RoutesType>>(
        "searchRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Routes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Routes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Routes 

      Field<ListGraphType<RoutesType>>(
        "listRoutes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Routes>("Routes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Routes #############################################3

      #region pesquisar dados de Methods 

      Field<ListGraphType<MethodsType>>(
        "searchMethods",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Methods();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Methods>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Methods 

      Field<ListGraphType<MethodsType>>(
        "listMethods",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Methods>("Methods");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Methods #############################################3

      #region pesquisar dados de RoutesMethods 

      Field<ListGraphType<RoutesMethodsType>>(
        "searchRoutesMethods",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new RoutesMethods();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<RoutesMethods>(models, id);
        }
      );

      #endregion;

      #region Listar dados de RoutesMethods 

      Field<ListGraphType<RoutesMethodsType>>(
        "listRoutesMethods",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<RoutesMethods>("RoutesMethods");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela RoutesMethods #############################################3

      #region pesquisar dados de Headers 

      Field<ListGraphType<HeadersType>>(
        "searchHeaders",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Headers();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Headers>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Headers 

      Field<ListGraphType<HeadersType>>(
        "listHeaders",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Headers>("Headers");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Headers #############################################3

      #region pesquisar dados de HeadersRoutes 

      Field<ListGraphType<HeadersRoutesType>>(
        "searchHeadersRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new HeadersRoutes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<HeadersRoutes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de HeadersRoutes 

      Field<ListGraphType<HeadersRoutesType>>(
        "listHeadersRoutes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<HeadersRoutes>("HeadersRoutes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela HeadersRoutes #############################################3

      #region pesquisar dados de PathsRoutes 

      Field<ListGraphType<PathsRoutesType>>(
        "searchPathsRoutes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new PathsRoutes();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<PathsRoutes>(models, id);
        }
      );

      #endregion;

      #region Listar dados de PathsRoutes 

      Field<ListGraphType<PathsRoutesType>>(
        "listPathsRoutes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<PathsRoutes>("PathsRoutes");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela PathsRoutes #############################################3

      #region pesquisar dados de RoutesTags 

      Field<ListGraphType<RoutesTagsType>>(
        "searchRoutesTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new RoutesTags();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<RoutesTags>(models, id);
        }
      );

      #endregion;

      #region Listar dados de RoutesTags 

      Field<ListGraphType<RoutesTagsType>>(
        "listRoutesTags",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<RoutesTags>("RoutesTags");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela RoutesTags #############################################3

      #region pesquisar dados de Tags 

      Field<ListGraphType<TagsType>>(
        "searchTags",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Tags();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Tags>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Tags 

      Field<ListGraphType<TagsType>>(
        "listTags",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Tags>("Tags");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Tags #############################################3

      #region pesquisar dados de Service 

      Field<ListGraphType<ServiceType>>(
        "searchService",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Service();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Service>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Service 

      Field<ListGraphType<ServiceType>>(
        "listService",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Service>("Service");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Service #############################################3

      #region pesquisar dados de ServiceTYPE 

      Field<ListGraphType<MicroServiceTypeType>>(
        "searchMicroServiceType",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new MicroServiceType();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<MicroServiceType>(models, id);
        }
      );

      #endregion;

      #region Listar dados de ServiceTYPE 

      Field<ListGraphType<MicroServiceTypeType>>(
        "listMicroServiceType",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<MicroServiceType>("MicroServiceType");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ServiceTYPE #############################################3

      #region pesquisar dados de Queue 

      Field<ListGraphType<QueueType>>(
        "searchQueue",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Queue();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Queue>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Queue 

      Field<ListGraphType<QueueType>>(
        "listQueue",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Queue>("Queue");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Queue #############################################3

      #region pesquisar dados de MethodQueue 

      Field<ListGraphType<MethodQueueType>>(
        "searchMethodQueue",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new MethodQueue();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<MethodQueue>(models, id);
        }
      );

      #endregion;

      #region Listar dados de MethodQueue 

      Field<ListGraphType<MethodQueueType>>(
        "listMethodQueue",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<MethodQueue>("MethodQueue");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela MethodQueue #############################################3

      #region pesquisar dados de Types 

      Field<ListGraphType<TypesType>>(
        "searchTypes",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Types();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Types>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Types 

      Field<ListGraphType<TypesType>>(
        "listTypes",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Types>("Types");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Types #############################################3

      #region pesquisar dados de RouteProtocols 

      Field<ListGraphType<RouteProtocolsType>>(
        "searchRouteProtocols",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new RouteProtocols();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<RouteProtocols>(models, id);
        }
      );

      #endregion;

      #region Listar dados de RouteProtocols 

      Field<ListGraphType<RouteProtocolsType>>(
        "listRouteProtocols",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<RouteProtocols>("RouteProtocols");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela RouteProtocols #############################################3

      #region pesquisar dados de Hosts 

      Field<ListGraphType<HostsType>>(
        "searchHosts",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new Hosts();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<Hosts>(models, id);
        }
      );

      #endregion;

      #region Listar dados de Hosts 

      Field<ListGraphType<HostsType>>(
        "listHosts",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<Hosts>("Hosts");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Hosts #############################################3

      #region pesquisar dados de MicroServiceConfig 

      Field<ListGraphType<MicroServiceConfigType>>(
        "searchMicroServiceConfig",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new MicroServiceConfig();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<MicroServiceConfig>(models, id);
        }
      );

      #endregion;

      #region Listar dados de MicroServiceConfig 

      Field<ListGraphType<MicroServiceConfigType>>(
        "listMicroServiceConfig",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<MicroServiceConfig>("MicroServiceConfig");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela MicroServiceConfig #############################################3





      #region pesquisar dados de MicroServices 

      Field<ListGraphType<MicroServicesType>>(
        "searchMicroServices",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id", }
        ),
        resolve: context =>
        {

          var models = new MicroServices();
          var id = context.GetArgument<string>("id");

          return contextServiceLocator.Repository.selectOne<MicroServices>(models, id);
        }
      );

      #endregion;

      #region Listar dados de MicroServices 

      Field<ListGraphType<MicroServicesType>>(
        "listMicroServices",
        resolve: context =>
        {
          return contextServiceLocator.Repository.select<MicroServices>("MicroServices");
        }
      );

      #endregion;

      //######################################## Fim da listagem da tabela MicroServiceConfig #############################################3





      #region pesquisar dados de AmbientTypes 

      Field<ListGraphType<AmbientTypesType>>(
        "searchAmbientTypes",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new AmbientTypes();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<AmbientTypes>(models, id);
            }
          );

      #endregion;


      #region Listar dados de AmbientTypes 

      Field<ListGraphType<AmbientTypesType>>(
        "listAmbientTypes",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<AmbientTypes>("AmbientTypes");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela AmbientTypes #############################################3




      #region pesquisar dados de CategoryRoutes 

      Field<ListGraphType<CategoryRoutesType>>(
        "searchCategoryRoutes",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new CategoryRoutes();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<CategoryRoutes>(models, id);
            }
          );

      #endregion;


      #region Listar dados de CategoryRoutes 

      Field<ListGraphType<CategoryRoutesType>>(
        "listCategoryRoutes",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<CategoryRoutes>("CategoryRoutes");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela CategoryRoutes #############################################3




      #region pesquisar dados de SubCategoryRoutes 

      Field<ListGraphType<SubCategoryRoutesType>>(
        "searchSubCategoryRoutes",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new SubCategoryRoutes();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<SubCategoryRoutes>(models, id);
            }
          );

      #endregion;


      #region Listar dados de SubCategoryRoutes 

      Field<ListGraphType<SubCategoryRoutesType>>(
        "listSubCategoryRoutes",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<SubCategoryRoutes>("SubCategoryRoutes");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela SubCategoryRoutes #############################################3




      #region pesquisar dados de Fields 

      Field<ListGraphType<FieldsType>>(
        "searchFields",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new Fields();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<Fields>(models, id);
            }
          );

      #endregion;


      #region Listar dados de Fields 

      Field<ListGraphType<FieldsType>>(
        "listFields",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<Fields>("Fields");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Fields #############################################3




      #region pesquisar dados de Restrictions 

      Field<ListGraphType<RestrictionsType>>(
        "searchRestrictions",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new Restrictions();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<Restrictions>(models, id);
            }
          );

      #endregion;


      #region Listar dados de Restrictions 

      Field<ListGraphType<RestrictionsType>>(
        "listRestrictions",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<Restrictions>("Restrictions");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Restrictions #############################################3










      #region pesquisar dados de SchemaGraphQ 

      Field<ListGraphType<SchemaGraphQType>>(
        "searchSchemaGraphQ",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new SchemaGraphQ();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<SchemaGraphQ>(models, id);
            }
          );

      #endregion;


      #region Listar dados de SchemaGraphQ 

      Field<ListGraphType<SchemaGraphQType>>(
        "listSchemaGraphQ",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<SchemaGraphQ>("SchemaGraphQ");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela SchemaGraphQ #############################################3




      #region pesquisar dados de SchemaRoute 

      Field<ListGraphType<SchemaRouteType>>(
        "searchSchemaRoute",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new SchemaRoute();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<SchemaRoute>(models, id);
            }
          );

      #endregion;


      #region Listar dados de SchemaRoute 

      Field<ListGraphType<SchemaRouteType>>(
        "listSchemaRoute",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<SchemaRoute>("SchemaRoute");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela SchemaRoute #############################################3




      #region pesquisar dados de Members 

      Field<ListGraphType<MembersType>>(
        "searchMembers",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new Members();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<Members>(models, id);
            }
          );

      #endregion;


      #region Listar dados de Members 

      Field<ListGraphType<MembersType>>(
        "listMembers",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<Members>("Members");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Members #############################################3




      #region pesquisar dados de MembersClientClients 

      Field<ListGraphType<MembersClientType>>(
        "searchMembersClient",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new MembersClient();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<MembersClient>(models, id);
            }
          );

      #endregion;


      #region Listar dados de MembersClientClients 

      Field<ListGraphType<MembersClientType>>(
        "listMembersClient",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<MembersClient>("MembersClient");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela MembersClientClients #############################################3




      #region pesquisar dados de ActividadeEmpresa 

      Field<ListGraphType<ActivityCompanyType>>(
        "searchActivityCompany",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new ActivityCompany();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<ActivityCompany>(models, id);
            }
          );

      #endregion;


      #region Listar dados de ActividadeEmpresa 

      Field<ListGraphType<ActivityCompanyType>>(
        "listActivityCompany",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<ActivityCompany>("ActivityCompany");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela ActividadeEmpresa #############################################3




      #region pesquisar dados de PersonType 

      Field<ListGraphType<PersonTypeType>>(
        "searchPersonType",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new PersonType();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<PersonType>(models, id);
            }
          );

      #endregion;


      #region Listar dados de PersonType 

      Field<ListGraphType<PersonTypeType>>(
        "listPersonType",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<PersonType>("PersonType");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela PersonType #############################################3




      #region pesquisar dados de Person 

      Field<ListGraphType<PersonsType>>(
        "searchPersons",
          arguments: new QueryArguments(
            new QueryArgument<StringGraphType> { Name = "id", }
            ),
            resolve: context =>
            {

              var models = new Persons();
              var id = context.GetArgument<string>("id");

              return contextServiceLocator.Repository.selectOne<Persons>(models, id);
            }
          );

      #endregion;


      #region Listar dados de Person 

      Field<ListGraphType<PersonsType>>(
        "listPersons",
          resolve: context =>
          {
            return contextServiceLocator.Repository.select<Persons>("Persons");
          }
      );

      #endregion;

      //######################################## Fim da listagem da tabela Person #############################################3


      

#region pesquisar dados de Canal 

Field<ListGraphType<CanalType>> (
  "searchCanal",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Canal();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Canal> (models, id);
      }
    );

#endregion;


#region Listar dados de Canal 

Field<ListGraphType<CanalType>> (
  "listCanal",
    resolve : context => {
      return contextServiceLocator.Repository.select<Canal> ("Canal");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Canal #############################################3


 

#region pesquisar dados de RoutesCanal 

Field<ListGraphType<RoutesCanalType>> (
  "searchRoutesCanal",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new RoutesCanal();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<RoutesCanal> (models, id);
      }
    );

#endregion;


#region Listar dados de RoutesCanal 

Field<ListGraphType<RoutesCanalType>> (
  "listRoutesCanal",
    resolve : context => {
      return contextServiceLocator.Repository.select<RoutesCanal> ("RoutesCanal");
    }
);

#endregion;

//######################################## Fim da listagem da tabela RoutesCanal #############################################3


#region pesquisar dados de UserProfile 

Field<ListGraphType<UserProfileType>> (
  "searchUserProfile",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new UserProfile();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<UserProfile> (models, id);
      }
    );

#endregion;


#region Listar dados de UserProfile 

Field<ListGraphType<UserProfileType>> (
  "listUserProfile",
    resolve : context => {
      return contextServiceLocator.Repository.select<UserProfile> ("UserProfile");
    }
);

#endregion;

//######################################## Fim da listagem da tabela UserProfile #############################################3


 

#region pesquisar dados de TypeReturns 

Field<ListGraphType<TypeReturnsType>> (
  "searchTypeReturns",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new TypeReturns();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<TypeReturns> (models, id);
      }
    );

#endregion;


#region Listar dados de TypeReturns 

Field<ListGraphType<TypeReturnsType>> (
  "listTypeReturns",
    resolve : context => {
      return contextServiceLocator.Repository.select<TypeReturns> ("TypeReturns");
    }
);

#endregion;

//######################################## Fim da listagem da tabela TypeReturns #############################################3


 

#region pesquisar dados de ServiceEmail 

Field<ListGraphType<ServiceEmailType>> (
  "searchServiceEmail",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new ServiceEmail();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<ServiceEmail> (models, id);
      }
    );

#endregion;


#region Listar dados de ServiceEmail 

Field<ListGraphType<ServiceEmailType>> (
  "listServiceEmail",
    resolve : context => {
      return contextServiceLocator.Repository.select<ServiceEmail> ("ServiceEmail");
    }
);

#endregion;

//######################################## Fim da listagem da tabela ServiceEmail #############################################3


 

#region pesquisar dados de SpecialRoutes 

Field<ListGraphType<SpecialRoutesType>> (
  "searchSpecialRoutes",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new SpecialRoutes();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<SpecialRoutes> (models, id);
      }
    );

#endregion;


#region Listar dados de SpecialRoutes 

Field<ListGraphType<SpecialRoutesType>> (
  "listSpecialRoutes",
    resolve : context => {
      return contextServiceLocator.Repository.select<SpecialRoutes> ("SpecialRoutes");
    }
);

#endregion;

//######################################## Fim da listagem da tabela SpecialRoutes #############################################3


 

#region pesquisar dados de SpecialRoutesRelationship 

Field<ListGraphType<SpecialRoutesRelationshipType>> (
  "searchSpecialRoutesRelationship",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new SpecialRoutesRelationship();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<SpecialRoutesRelationship> (models, id);
      }
    );

#endregion;


#region Listar dados de SpecialRoutesRelationship 

Field<ListGraphType<SpecialRoutesRelationshipType>> (
  "listSpecialRoutesRelationship",
    resolve : context => {
      return contextServiceLocator.Repository.select<SpecialRoutesRelationship> ("SpecialRoutesRelationship");
    }
);

#endregion;

//######################################## Fim da listagem da tabela SpecialRoutesRelationship #############################################3


 

#region pesquisar dados de PerfilMembers 

Field<ListGraphType<PerfilMembersType>> (
  "searchPerfilMembers",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new PerfilMembers();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<PerfilMembers> (models, id);
      }
    );

#endregion;


#region Listar dados de PerfilMembers 

Field<ListGraphType<PerfilMembersType>> (
  "listPerfilMembers",
    resolve : context => {
      return contextServiceLocator.Repository.select<PerfilMembers> ("PerfilMembers");
    }
);

#endregion;

//######################################## Fim da listagem da tabela PerfilMembers #############################################3


 

#region pesquisar dados de Menu 

Field<ListGraphType<MenuType>> (
  "searchMenu",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Menu();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Menu> (models, id);
      }
    );

#endregion;


#region Listar dados de Menu 

Field<ListGraphType<MenuType>> (
  "listMenu",
    resolve : context => {
      return contextServiceLocator.Repository.select<Menu> ("Menu");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Menu #############################################3


 

#region pesquisar dados de MenuMethod 

Field<ListGraphType<MenuMethodType>> (
  "searchMenuMethod",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new MenuMethod();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<MenuMethod> (models, id);
      }
    );

#endregion;


#region Listar dados de MenuMethod 

Field<ListGraphType<MenuMethodType>> (
  "listMenuMethod",
    resolve : context => {
      return contextServiceLocator.Repository.select<MenuMethod> ("MenuMethod");
    }
);

#endregion;

//######################################## Fim da listagem da tabela MenuMethod #############################################3


 

#region pesquisar dados de MenuPerfil 

Field<ListGraphType<MenuPerfilType>> (
  "searchMenuPerfil",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new MenuPerfil();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<MenuPerfil> (models, id);
      }
    );

#endregion;


#region Listar dados de MenuPerfil 

Field<ListGraphType<MenuPerfilType>> (
  "listMenuPerfil",
    resolve : context => {
      return contextServiceLocator.Repository.select<MenuPerfil> ("MenuPerfil");
    }
);

#endregion;

//######################################## Fim da listagem da tabela MenuPerfil #############################################3


 

#region pesquisar dados de PerfilClient 

Field<ListGraphType<PerfilClientType>> (
  "searchPerfilClient",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new PerfilClient();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<PerfilClient> (models, id);
      }
    );

#endregion;


#region Listar dados de PerfilClient 

Field<ListGraphType<PerfilClientType>> (
  "listPerfilClient",
    resolve : context => {
      return contextServiceLocator.Repository.select<PerfilClient> ("PerfilClient");
    }
);

#endregion;

//######################################## Fim da listagem da tabela PerfilClient #############################################3


 

#region pesquisar dados de ProfileMenu 

Field<ListGraphType<ProfileMenuType>> (
  "searchProfileMenu",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new ProfileMenu();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<ProfileMenu> (models, id);
      }
    );

#endregion;


#region Listar dados de ProfileMenu 

Field<ListGraphType<ProfileMenuType>> (
  "listProfileMenu",
    resolve : context => {
      return contextServiceLocator.Repository.select<ProfileMenu> ("ProfileMenu");
    }
);

#endregion;

//######################################## Fim da listagem da tabela ProfileMenu #############################################3


 

#region pesquisar dados de ProfileMenuMethods 

Field<ListGraphType<ProfileMenuMethodsType>> (
  "searchProfileMenuMethods",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new ProfileMenuMethods();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<ProfileMenuMethods> (models, id);
      }
    );

#endregion;


#region Listar dados de ProfileMenuMethods 

Field<ListGraphType<ProfileMenuMethodsType>> (
  "listProfileMenuMethods",
    resolve : context => {
      return contextServiceLocator.Repository.select<ProfileMenuMethods> ("ProfileMenuMethods");
    }
);

#endregion;

//######################################## Fim da listagem da tabela ProfileMenuMethods #############################################3


 


 

#region pesquisar dados de Statuss 

Field<ListGraphType<StatussType>> (
  "searchStatuss",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Statuss();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Statuss> (models, id);
      }
    );

#endregion;


#region Listar dados de Statuss 

Field<ListGraphType<StatussType>> (
  "listStatuss",
    resolve : context => {
      return contextServiceLocator.Repository.select<Statuss> ("Statuss");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Statuss #############################################3


 

#region pesquisar dados de Continent 

Field<ListGraphType<ContinentType>> (
  "searchContinent",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Continent();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Continent> (models, id);
      }
    );

#endregion;


#region Listar dados de Continent 

Field<ListGraphType<ContinentType>> (
  "listContinent",
    resolve : context => {
      return contextServiceLocator.Repository.select<Continent> ("Continent");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Continent #############################################3


 

#region pesquisar dados de Region 

Field<ListGraphType<RegionType>> (
  "searchRegion",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Region();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Region> (models, id);
      }
    );

#endregion;


#region Listar dados de Region 

Field<ListGraphType<RegionType>> (
  "listRegion",
    resolve : context => {
      return contextServiceLocator.Repository.select<Region> ("Region");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Region #############################################3


 

 

#region pesquisar dados de Country 

Field<ListGraphType<CountryType>> (
  "searchCountry",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Country();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Country> (models, id);
      }
    );

#endregion;


#region Listar dados de Country 

Field<ListGraphType<CountryType>> (
  "listCountry",
    resolve : context => {
      return contextServiceLocator.Repository.select<Country> ("Country");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Country #############################################3


 

#region pesquisar dados de Province 

Field<ListGraphType<ProvinceType>> (
  "searchProvince",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Province();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Province> (models, id);
      }
    );

#endregion;


#region Listar dados de Province 

Field<ListGraphType<ProvinceType>> (
  "listProvince",
    resolve : context => {
      return contextServiceLocator.Repository.select<Province> ("Province");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Province #############################################3


 

#region pesquisar dados de County 

Field<ListGraphType<CountyType>> (
  "searchCounty",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new County();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<County> (models, id);
      }
    );

#endregion;


#region Listar dados de County 

Field<ListGraphType<CountyType>> (
  "listCounty",
    resolve : context => {
      return contextServiceLocator.Repository.select<County> ("County");
    }
);

#endregion;

//######################################## Fim da listagem da tabela County #############################################3


 

#region pesquisar dados de District 

Field<ListGraphType<DistrictType>> (
  "searchDistrict",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new District();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<District> (models, id);
      }
    );

#endregion;


#region Listar dados de District 

Field<ListGraphType<DistrictType>> (
  "listDistrict",
    resolve : context => {
      return contextServiceLocator.Repository.select<District> ("District");
    }
);

#endregion;

//######################################## Fim da listagem da tabela District #############################################3


 

#region pesquisar dados de Neighborhood 

Field<ListGraphType<NeighborhoodType>> (
  "searchNeighborhood",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Neighborhood();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Neighborhood> (models, id);
      }
    );

#endregion;


#region Listar dados de Neighborhood 

Field<ListGraphType<NeighborhoodType>> (
  "listNeighborhood",
    resolve : context => {
      return contextServiceLocator.Repository.select<Neighborhood> ("Neighborhood");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Neighborhood #############################################3


 

#region pesquisar dados de Street 

Field<ListGraphType<StreetType>> (
  "searchStreet",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Street();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Street> (models, id);
      }
    );

#endregion;


#region Listar dados de Street 

Field<ListGraphType<StreetType>> (
  "listStreet",
    resolve : context => {
      return contextServiceLocator.Repository.select<Street> ("Street");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Street #############################################3


 

#region pesquisar dados de City 

Field<ListGraphType<CityType>> (
  "searchCity",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new City();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<City> (models, id);
      }
    );

#endregion;


#region Listar dados de City 

Field<ListGraphType<CityType>> (
  "listCity",
    resolve : context => {
      return contextServiceLocator.Repository.select<City> ("City");
    }
);

#endregion;

//######################################## Fim da listagem da tabela City #############################################3


 

#region pesquisar dados de RoutesCountries 

Field<ListGraphType<RoutesCountriesType>> (
  "searchRoutesCountries",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new RoutesCountries();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<RoutesCountries> (models, id);
      }
    );

#endregion;


#region Listar dados de RoutesCountries 

Field<ListGraphType<RoutesCountriesType>> (
  "listRoutesCountries",
    resolve : context => {
      return contextServiceLocator.Repository.select<RoutesCountries> ("RoutesCountries");
    }
);

#endregion;

//######################################## Fim da listagem da tabela RoutesCountries #############################################3


 

#region pesquisar dados de SelectedProvinces 

Field<ListGraphType<SelectedProvincesType>> (
  "searchSelectedProvinces",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new SelectedProvinces();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<SelectedProvinces> (models, id);
      }
    );

#endregion;


#region Listar dados de SelectedProvinces 

Field<ListGraphType<SelectedProvincesType>> (
  "listSelectedProvinces",
    resolve : context => {
      return contextServiceLocator.Repository.select<SelectedProvinces> ("SelectedProvinces");
    }
);

#endregion;

//######################################## Fim da listagem da tabela SelectedProvinces #############################################3


 

#region pesquisar dados de RouteAnalytics 

Field<ListGraphType<RouteAnalyticsType>> (
  "searchRouteAnalytics",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new RouteAnalytics();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<RouteAnalytics> (models, id);
      }
    );

#endregion;


#region Listar dados de RouteAnalytics 

Field<ListGraphType<RouteAnalyticsType>> (
  "listRouteAnalytics",
    resolve : context => {
      return contextServiceLocator.Repository.select<RouteAnalytics> ("RouteAnalytics");
    }
);

#endregion;

//######################################## Fim da listagem da tabela RouteAnalytics #############################################3


 

#region pesquisar dados de MetricTypes 

Field<ListGraphType<MetricTypesType>> (
  "searchMetricTypes",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new MetricTypes();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<MetricTypes> (models, id);
      }
    );

#endregion;


#region Listar dados de MetricTypes 

Field<ListGraphType<MetricTypesType>> (
  "listMetricTypes",
    resolve : context => {
      return contextServiceLocator.Repository.select<MetricTypes> ("MetricTypes");
    }
);

#endregion;

//######################################## Fim da listagem da tabela MetricTypes #############################################3


 

#region pesquisar dados de IntervalUnits 

Field<ListGraphType<IntervalUnitsType>> (
  "searchIntervalUnits",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new IntervalUnits();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<IntervalUnits> (models, id);
      }
    );

#endregion;


#region Listar dados de IntervalUnits 

Field<ListGraphType<IntervalUnitsType>> (
  "listIntervalUnits",
    resolve : context => {
      return contextServiceLocator.Repository.select<IntervalUnits> ("IntervalUnits");
    }
);

#endregion;

//######################################## Fim da listagem da tabela IntervalUnits #############################################3


 

#region pesquisar dados de Alerts 

Field<ListGraphType<AlertsType>> (
  "searchAlerts",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Alerts();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Alerts> (models, id);
      }
    );

#endregion;


#region Listar dados de Alerts 

Field<ListGraphType<AlertsType>> (
  "listAlerts",
    resolve : context => {
      return contextServiceLocator.Repository.select<Alerts> ("Alerts");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Alerts #############################################3


 

#region pesquisar dados de StatusCode 

Field<ListGraphType<StatusCodeType>> (
  "searchStatusCode",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new StatusCode();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<StatusCode> (models, id);
      }
    );

#endregion;


#region Listar dados de StatusCode 

Field<ListGraphType<StatusCodeType>> (
  "listStatusCode",
    resolve : context => {
      return contextServiceLocator.Repository.select<StatusCode> ("StatusCode");
    }
);

#endregion;

//######################################## Fim da listagem da tabela StatusCode #############################################3


 

#region pesquisar dados de StatusCodeAlert 

Field<ListGraphType<StatusCodeAlertType>> (
  "searchStatusCodeAlert",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new StatusCodeAlert();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<StatusCodeAlert> (models, id);
      }
    );

#endregion;


#region Listar dados de StatusCodeAlert 

Field<ListGraphType<StatusCodeAlertType>> (
  "listStatusCodeAlert",
    resolve : context => {
      return contextServiceLocator.Repository.select<StatusCodeAlert> ("StatusCodeAlert");
    }
);

#endregion;

//######################################## Fim da listagem da tabela StatusCodeAlert #############################################3


 

#region pesquisar dados de ThrottleInterval 

Field<ListGraphType<ThrottleIntervalType>> (
  "searchThrottleInterval",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new ThrottleInterval();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<ThrottleInterval> (models, id);
      }
    );

#endregion;


#region Listar dados de ThrottleInterval 

Field<ListGraphType<ThrottleIntervalType>> (
  "listThrottleInterval",
    resolve : context => {
      return contextServiceLocator.Repository.select<ThrottleInterval> ("ThrottleInterval");
    }
);

#endregion;

//######################################## Fim da listagem da tabela ThrottleInterval #############################################3


 

#region pesquisar dados de MetricConditions 

Field<ListGraphType<MetricConditionsType>> (
  "searchMetricConditions",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new MetricConditions();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<MetricConditions> (models, id);
      }
    );

#endregion;


#region Listar dados de MetricConditions 

Field<ListGraphType<MetricConditionsType>> (
  "listMetricConditions",
    resolve : context => {
      return contextServiceLocator.Repository.select<MetricConditions> ("MetricConditions");
    }
);

#endregion;

//######################################## Fim da listagem da tabela MetricConditions #############################################3


 

#region pesquisar dados de TypeAlert 

Field<ListGraphType<TypeAlertType>> (
  "searchTypeAlert",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new TypeAlert();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<TypeAlert> (models, id);
      }
    );

#endregion;


#region Listar dados de TypeAlert 

Field<ListGraphType<TypeAlertType>> (
  "listTypeAlert",
    resolve : context => {
      return contextServiceLocator.Repository.select<TypeAlert> ("TypeAlert");
    }
);

#endregion;

//######################################## Fim da listagem da tabela TypeAlert #############################################3


 

#region pesquisar dados de Documentation 

Field<ListGraphType<DocumentationType>> (
  "searchDocumentation",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Documentation();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Documentation> (models, id);
      }
    );

#endregion;


#region Listar dados de Documentation 

Field<ListGraphType<DocumentationType>> (
  "listDocumentation",
    resolve : context => {
      return contextServiceLocator.Repository.select<Documentation> ("Documentation");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Documentation #############################################3


 

#region pesquisar dados de Plugin 

Field<ListGraphType<PluginType>> (
  "searchPlugin",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Plugin();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Plugin> (models, id);
      }
    );

#endregion;


#region Listar dados de Plugin 

Field<ListGraphType<PluginType>> (
  "listPlugin",
    resolve : context => {
      return contextServiceLocator.Repository.select<Plugin> ("Plugin");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Plugin #############################################3


 

#region pesquisar dados de PluginConfig 

Field<ListGraphType<PluginConfigType>> (
  "searchPluginConfig",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new PluginConfig();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<PluginConfig> (models, id);
      }
    );

#endregion;


#region Listar dados de PluginConfig 

Field<ListGraphType<PluginConfigType>> (
  "listPluginConfig",
    resolve : context => {
      return contextServiceLocator.Repository.select<PluginConfig> ("PluginConfig");
    }
);

#endregion;

//######################################## Fim da listagem da tabela PluginConfig #############################################3


 

 

 

#region pesquisar dados de Datasheet 

Field<ListGraphType<DatasheetType>> (
  "searchDatasheet",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Datasheet();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Datasheet> (models, id);
      }
    );

#endregion;


#region Listar dados de Datasheet 

Field<ListGraphType<DatasheetType>> (
  "listDatasheet",
    resolve : context => {
      return contextServiceLocator.Repository.select<Datasheet> ("Datasheet");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Datasheet #############################################3


 

#region pesquisar dados de Distribution 

Field<ListGraphType<DistributionType>> (
  "searchDistribution",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Distribution();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Distribution> (models, id);
      }
    );

#endregion;


#region Listar dados de Distribution 

Field<ListGraphType<DistributionType>> (
  "listDistribution",
    resolve : context => {
      return contextServiceLocator.Repository.select<Distribution> ("Distribution");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Distribution #############################################3


 

#region pesquisar dados de Error 

Field<ListGraphType<ErrorType>> (
  "searchError",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Error();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Error> (models, id);
      }
    );

#endregion;


#region Listar dados de Error 

Field<ListGraphType<ErrorType>> (
  "listError",
    resolve : context => {
      return contextServiceLocator.Repository.select<Error> ("Error");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Error #############################################3


 
#region pesquisar dados de Indice 

Field<ListGraphType<IndiceType>> (
  "searchIndice",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Indice();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Indice> (models, id);
      }
    );

#endregion;


#region Listar dados de Indice 

Field<ListGraphType<IndiceType>> (
  "listIndice",
    resolve : context => {
      return contextServiceLocator.Repository.select<Indice> ("Indice");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Indice #############################################3


 

#region pesquisar dados de Item 

Field<ListGraphType<ItemType>> (
  "searchItem",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Item();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Item> (models, id);
      }
    );

#endregion;


#region Listar dados de Item 

Field<ListGraphType<ItemType>> (
  "listItem",
    resolve : context => {
      return contextServiceLocator.Repository.select<Item> ("Item");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Item #############################################3


 

#region pesquisar dados de Work 

Field<ListGraphType<WorkType>> (
  "searchWork",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Work();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Work> (models, id);
      }
    );

#endregion;


#region Listar dados de Work 

Field<ListGraphType<WorkType>> (
  "listWork",
    resolve : context => {
      return contextServiceLocator.Repository.select<Work> ("Work");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Work #############################################3


 

#region pesquisar dados de Url 

Field<ListGraphType<UrlType>> (
  "searchUrl",
    arguments : new QueryArguments (
      new QueryArgument<StringGraphType> { Name = "id", }
      ),
      resolve : context => {

        var models = new Url();
        var id =context.GetArgument<string>("id");

        return contextServiceLocator.Repository.selectOne<Url> (models, id);
      }
    );

#endregion;


#region Listar dados de Url 

Field<ListGraphType<UrlType>> (
  "listUrl",
    resolve : context => {
      return contextServiceLocator.Repository.select<Url> ("Url");
    }
);

#endregion;

//######################################## Fim da listagem da tabela Url #############################################3


 //AppQueryFields

    }
  }
}






