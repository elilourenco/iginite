using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ApiResourcesType : ObjectGraphType<ApiResources>
  {
    public ApiResourcesType()
    {
      Name = "ApiResources";
      Field(x => x.Id, nullable: true);
      Field(x => x.ClientId, nullable: true);
      Field(x => x.Protocol, nullable: true);
      Field(x => x.Enabled, nullable: true); 
      Field(x => x.Name, nullable: true); 
      Field(x => x.DisplayName, nullable: true); 
      Field(x => x.Description, nullable: true); 
      Field(x => x.AllowedAccessTokenSigningAlgorithms, nullable: true); 
      Field(x => x.ShowInDiscoveryDocument, nullable: true);
      Field(x => x.Created, nullable: true); 
      Field(x => x.Updated, nullable: true); 
      Field(x => x.LastAccessed, nullable: true); 
      Field(x => x.NonEditable, nullable: true); 
      Field(x => x.host, nullable: true); 
      Field(x => x.path, nullable: true); 
      Field(x => x.port, nullable: true); 
      Field(x => x.retries, nullable: true); 
      Field(x => x.connectTimeout, nullable: true); 
      Field(x => x.writeTimeout, nullable: true); 
      Field(x => x.readTimeout, nullable: true); 
      Field(x => x.clientCertificate, nullable: true);
      Field(x => x.TypeId, nullable: true);
      FieldAsync<ListGraphType<MicroServiceConfigType>>("MicroServiceConfigs", resolve: async c=>c.Source.MicroServiceConfig);
      FieldAsync<ListGraphType<ClientsType>>("Clients", resolve: async c => c.Source.ClientId==null?null: new manipulacao().selectOne<Clients>(new Clients(), c.Source.ClientId.ToString()));
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<Routes>(new Routes(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<TypesType>>("Types", resolve: async c => c.Source.TypeId==null?null: new manipulacao().selectOne<Types>(new Types(), c.Source.TypeId.ToString()));
      FieldAsync<ListGraphType<MicroServiceConfigType>>("MicroServiceConfig", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<MicroServiceConfig>(new MicroServiceConfig(), c.Source.Id.ToString()));
      
    }
  }
  public class ApiResourcesInputType : InputObjectGraphType
  {
    public ApiResourcesInputType()
    {
      Name = "ApiResourcesInput";
      Field<BooleanGraphType>("Id");
      Field<BooleanGraphType>("Enabled"); 
      Field<StringGraphType>("Name"); 
      Field<StringGraphType>("DisplayName"); 
      Field<StringGraphType>("Description"); 
      Field<StringGraphType>("AllowedAccessTokenSigningAlgorithms"); 
      Field<BooleanGraphType>("ShowInDiscoveryDocument"); 
      Field<DateTimeGraphType>("Created"); 
      Field<DateTimeGraphType>("Updated"); 
      Field<DateTimeGraphType>("LastAccessed"); 
      Field<BooleanGraphType>("NonEditable"); 
      Field<StringGraphType>("host"); 
      Field<StringGraphType>("path");
      Field<IntGraphType>("port");
      Field<IntGraphType>("retries");
      Field<IntGraphType>("connectTimeout");
      Field<IntGraphType>("writeTimeout"); 
      Field<IntGraphType>("readTimeout"); 
      Field<StringGraphType>("clientCertificate");
      Field<StringGraphType>("Protocol");
      Field<ClientsInputType>("Clients");
      Field<StringGraphType>("ClientId");
      Field<StringGraphType>("TypeId");
      Field<ListGraphType<MicroServiceConfigInputType>>("MicroServiceConfig");
    }
  }
}