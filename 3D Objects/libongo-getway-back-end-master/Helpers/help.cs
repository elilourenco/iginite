using GraphQL.Types;
using libongo.Type;
using Microsoft.Extensions.DependencyInjection;

namespace libongo.Helpers {
  public class help {
    public void ConfigureServices (IServiceCollection services) {
      services.AddSingleton<ApiResourceClaimsType> ();
      services.AddSingleton<ApiResourceClaimsInputType> ();
      services.AddSingleton<ApiResourcePropertiesType> ();
      services.AddSingleton<ApiResourcePropertiesInputType> ();
      services.AddSingleton<ApiResourcesType> ();
      services.AddSingleton<ApiResourcesInputType> ();
      services.AddSingleton<ApiResourceScopesType> ();
      services.AddSingleton<ApiResourceScopesInputType> ();
      services.AddSingleton<ApiResourceSecretsType> ();
      //services.AddSingleton<RepoType>();
      services.AddSingleton<ApiResourceSecretsInputType> ();
      services.AddSingleton<ApiScopeClaimsType> ();
      services.AddSingleton<ApiScopeClaimsInputType> ();
      services.AddSingleton<ApiScopePropertiesType> ();
      services.AddSingleton<ApiScopePropertiesInputType> ();
      services.AddSingleton<ApiScopesType> ();
      services.AddSingleton<ApiScopesInputType> ();
      services.AddSingleton<AspNetRoleClaimsType> ();
      services.AddSingleton<AspNetRoleClaimsInputType> ();
      services.AddSingleton<AspNetRolesType> ();
      services.AddSingleton<AspNetRolesInputType> ();
      services.AddSingleton<AspNetUserClaimsType> ();
      services.AddSingleton<AspNetUserClaimsInputType> ();
      services.AddSingleton<AspNetUserRolesType> ();
      services.AddSingleton<AspNetUserRolesInputType> ();
      services.AddSingleton<AspNetUsersType> ();
      services.AddSingleton<AspNetUsersInputType> ();
      services.AddSingleton<AspNetUserTokensType> ();
      services.AddSingleton<AspNetUserTokensInputType> ();
      services.AddSingleton<ClientClaimsType> ();
      services.AddSingleton<ClientClaimsInputType> ();
      services.AddSingleton<ClientCorsOriginsType> ();
      services.AddSingleton<ClientCorsOriginsInputType> ();
      services.AddSingleton<ClientGrantTypesType> ();
      services.AddSingleton<ClientGrantTypesInputType> ();
      services.AddSingleton<ClientIdPRestrictionsType> ();
      services.AddSingleton<ClientIdPRestrictionsInputType> ();
      services.AddSingleton<ClientPostLogoutRedirectUrisType> ();
      services.AddSingleton<ClientPostLogoutRedirectUrisInputType> ();
      services.AddSingleton<ClientPropertiesType> ();
      services.AddSingleton<ClientPropertiesInputType> ();
      services.AddSingleton<ClientRedirectUrisType> ();
      services.AddSingleton<ClientRedirectUrisInputType> ();
      services.AddSingleton<ClientsType> ();
      services.AddSingleton<ClientsInputType> ();
      services.AddSingleton<ClientScopesType> ();
      services.AddSingleton<ClientScopesInputType> ();
      services.AddSingleton<ClientSecretsType> ();
      services.AddSingleton<ClientSecretsInputType> ();
      services.AddSingleton<DeviceCodesType> ();
      services.AddSingleton<DeviceCodesInputType> ();
      services.AddSingleton<IdentityResourceClaimsType> ();
      services.AddSingleton<IdentityResourceClaimsInputType> ();
      services.AddSingleton<IdentityResourcePropertiesType> ();
      services.AddSingleton<IdentityResourcePropertiesInputType> ();
      services.AddSingleton<IdentityResourcesType> ();
      services.AddSingleton<IdentityResourcesInputType> ();
      services.AddSingleton<PersistedGrantsType> ();
      services.AddSingleton<PersistedGrantsInputType> ();
      services.AddSingleton<ClientClientsType> ();
      services.AddSingleton<ClientClientsInputType> ();
      services.AddSingleton<ClientClientsRoutesType> ();
      services.AddSingleton<ClientClientsRoutesInputType> ();
      services.AddSingleton<ProtocolsType> ();
      services.AddSingleton<ProtocolsInputType> ();
      services.AddSingleton<ApiResourcesTagsType> ();
      services.AddSingleton<ApiResourcesTagsInputType> ();
      services.AddSingleton<PathsType> ();
      services.AddSingleton<PathsInputType> ();
      services.AddSingleton<RoutesType> ();
      services.AddSingleton<RoutesInputType> ();
      services.AddSingleton<MethodsType> ();
      services.AddSingleton<MethodsInputType> ();
      services.AddSingleton<RoutesMethodsType> ();
      services.AddSingleton<RoutesMethodsInputType> ();
      services.AddSingleton<HeadersType> ();
      services.AddSingleton<HeadersInputType> ();
      services.AddSingleton<HeadersRoutesType> ();
      services.AddSingleton<HeadersRoutesInputType> ();
      services.AddSingleton<PathsRoutesType> ();
      services.AddSingleton<PathsRoutesInputType> ();
      services.AddSingleton<RoutesTagsType> ();
      services.AddSingleton<RoutesTagsInputType> ();
      services.AddSingleton<TagsType> ();
      services.AddSingleton<TagsInputType> ();
      services.AddSingleton<ApiGetWeyInputType> ();
      services.AddSingleton<ApiGetWeyType> ();
      services.AddSingleton<ServiceType> ();
      services.AddSingleton<ServiceInputType> ();
      services.AddSingleton<MicroServiceTypeType> ();
      services.AddSingleton<MicroServiceTypeInputType> ();
      services.AddSingleton<QueueType> ();
      services.AddSingleton<QueueInputType> ();
      services.AddSingleton<MethodQueueType> ();
      services.AddSingleton<MethodQueueInputType> ();
      services.AddSingleton<TypesType> ();
      services.AddSingleton<TypesInputType> ();
      services.AddSingleton<RouteProtocolsType> ();
      services.AddSingleton<RouteProtocolsInputType> ();
      services.AddSingleton<HostsType> ();
      services.AddSingleton<HostsInputType> ();
      services.AddSingleton<MicroServiceConfigType> ();
      services.AddSingleton<MicroServiceConfigInputType> ();
      services.AddSingleton<MicroServiceTypeType> ();
      services.AddSingleton<MicroServiceTypeInputType> ();
      services.AddSingleton<MicroServicesType> ();
      services.AddSingleton<MicroServicesInputType> ();
      services.AddSingleton<AmbientTypesType> ();
      services.AddSingleton<AmbientTypesInputType> ();
      services.AddSingleton<CategoryRoutesType> ();
      services.AddSingleton<CategoryRoutesInputType> ();
      services.AddSingleton<SubCategoryRoutesType> ();
      services.AddSingleton<SubCategoryRoutesInputType> ();
      services.AddSingleton<FieldsType> ();
      services.AddSingleton<FieldsInputType> ();
      services.AddSingleton<RestrictionsType> ();
      services.AddSingleton<RestrictionsInputType> ();
      services.AddSingleton<FieldApiType> ();
      services.AddSingleton<FieldApiTypeInputType> ();
      services.AddSingleton<SchemaGraphQType> ();
      services.AddSingleton<SchemaGraphQInputType> ();
      services.AddSingleton<SchemaRouteType> ();
      services.AddSingleton<SchemaRouteInputType> ();
      services.AddSingleton<MembersType> ();
      services.AddSingleton<MembersInputType> ();
      services.AddSingleton<MembersClientType> ();
      services.AddSingleton<MembersClientInputType> ();
      services.AddSingleton<ActivityCompanyType> ();
      services.AddSingleton<ActivityCompanyInputType> ();
      services.AddSingleton<PersonTypeType> ();
      services.AddSingleton<PersonTypeInputType> ();
      services.AddSingleton<PersonsType> ();
      services.AddSingleton<PersonsInputType> ();
      services.AddSingleton<CanalType> ();
      services.AddSingleton<CanalInputType> ();
      services.AddSingleton<RoutesCanalType> ();
      services.AddSingleton<RoutesCanalInputType> ();
      services.AddSingleton<UserProfileType> ();
      services.AddSingleton<UserProfileInputType> ();
      services.AddSingleton<TypeReturnsType> ();
      services.AddSingleton<TypeReturnsInputType> ();
      services.AddSingleton<LoginType> ();
      services.AddSingleton<LoginInputType> ();
      services.AddSingleton<ServiceEmailType> ();
      services.AddSingleton<ServiceEmailInputType> ();
      services.AddSingleton<SpecialRoutesType> ();
      services.AddSingleton<SpecialRoutesInputType> ();
      services.AddSingleton<SpecialRoutesRelationshipType> ();
      services.AddSingleton<SpecialRoutesRelationshipInputType> ();
      services.AddSingleton<PerfilMembersType> ();
      services.AddSingleton<PerfilMembersInputType> ();
      services.AddSingleton<MenuType> ();
      services.AddSingleton<MenuInputType> ();
      services.AddSingleton<MenuMethodType> ();
      services.AddSingleton<MenuMethodInputType> ();
      services.AddSingleton<MenuPerfilType> ();
      services.AddSingleton<MenuPerfilInputType> ();
      services.AddSingleton<PerfilClientType> ();
      services.AddSingleton<PerfilClientInputType> ();
      services.AddSingleton<ProfileMenuType> ();
      services.AddSingleton<ProfileMenuInputType> ();
      services.AddSingleton<ProfileMenuMethodsType> ();
      services.AddSingleton<ProfileMenuMethodsInputType> ();
      services.AddSingleton<AddressType> ();
      services.AddSingleton<GeolocalizacaoType> ();
      services.AddSingleton<GeolocalizacaoInputType> ();

      services.AddSingleton<StatussType> ();
      services.AddSingleton<StatussInputType> ();
      services.AddSingleton<ContinentType> ();
      services.AddSingleton<ContinentInputType> ();
      services.AddSingleton<RegionType> ();
      services.AddSingleton<RegionInputType> ();
      services.AddSingleton<CountryType> ();
      services.AddSingleton<CountryInputType> ();
      services.AddSingleton<ProvinceType> ();
      services.AddSingleton<ProvinceInputType> ();
      services.AddSingleton<CountyType> ();
      services.AddSingleton<CountyInputType> ();
      services.AddSingleton<DistrictType> ();
      services.AddSingleton<DistrictInputType> ();
      services.AddSingleton<NeighborhoodType> ();
      services.AddSingleton<NeighborhoodInputType> ();
      services.AddSingleton<StreetType> ();
      services.AddSingleton<StreetInputType> ();
      services.AddSingleton<CityType> ();
      services.AddSingleton<CityInputType> ();
      services.AddSingleton<RoutesCountriesType> ();
      services.AddSingleton<RoutesCountriesInputType> ();
      services.AddSingleton<SelectedProvincesType> ();
      services.AddSingleton<SelectedProvincesInputType> ();
      services.AddSingleton<RouteAnalyticsType> ();
      services.AddSingleton<RouteAnalyticsInputType> (); 
      services.AddSingleton<statisticsClientClientInputType> ();
      services.AddSingleton<statisticsClientClientType> ();
      services.AddSingleton<MetricTypesType>();
      services.AddSingleton<MetricTypesInputType>();  
      services.AddSingleton<IntervalUnitsType>();
      services.AddSingleton<IntervalUnitsInputType>();  
      services.AddSingleton<AlertsType>();
      services.AddSingleton<AlertsInputType>();  
      services.AddSingleton<StatusCodeType>();
      services.AddSingleton<StatusCodeInputType>();  
      services.AddSingleton<StatusCodeAlertType>();
      services.AddSingleton<StatusCodeAlertInputType>();  
      services.AddSingleton<ThrottleIntervalType>();
      services.AddSingleton<ThrottleIntervalInputType>();  
      services.AddSingleton<MetricConditionsType>();
      services.AddSingleton<MetricConditionsInputType>();  
      services.AddSingleton<TypeAlertType>();
      services.AddSingleton<TypeAlertInputType>();  
      services.AddSingleton<ApiDocumentationType>();
      services.AddSingleton<ApiDocumentationInputType>();
      services.AddSingleton<contactType>();
      services.AddSingleton<DocumentationheaderType>();
      services.AddSingleton<DocumentationType>();
      services.AddSingleton<DocumentationInputType>();  
      services.AddSingleton<PluginType>();
      services.AddSingleton<PluginInputType>();  
      services.AddSingleton<PluginConfigType>();
      services.AddSingleton<PluginConfigInputType>();  

      //Documentação das APIS
      services.AddSingleton<DatasheetType>();
      services.AddSingleton<DatasheetInputType>(); 
      services.AddSingleton<DistributionType>();
      services.AddSingleton<DistributionInputType>();  
      services.AddSingleton<ErrorType>();
      services.AddSingleton<ErrorInputType>();  
      services.AddSingleton<IndiceType>();
      services.AddSingleton<IndiceInputType>();  
      services.AddSingleton<ItemType>();
      services.AddSingleton<ItemInputType>();  
      services.AddSingleton<WorkType>();
      services.AddSingleton<WorkInputType>();  
      services.AddSingleton<UrlType>();
      services.AddSingleton<UrlInputType>();  
      
      
      //serviceaddSfgghhhghgh
    }
  }
}


















