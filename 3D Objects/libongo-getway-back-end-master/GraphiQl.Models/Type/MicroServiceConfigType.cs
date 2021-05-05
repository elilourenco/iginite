using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class MicroServiceConfigType : ObjectGraphType<MicroServiceConfig>
  {
    public MicroServiceConfigType()
    {
      Name = "MicroServiceConfig";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      Field(x => x.Ip, nullable: true);
      Field(x => x.Port, nullable: true);
      Field(x => x.Password, nullable: true);
      Field(x => x.UserName, nullable: true);
      Field(x => x.MicroServiceId, nullable: true);
      Field(x => x.ApiResourcesId, nullable: true); 
      Field(x => x.AmbientTypeId, nullable: true); 
      FieldAsync<ListGraphType<MicroServicesType>>("MicroServices", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<MicroServices>(new MicroServices(), c.Source.MicroServiceId.ToString()));
      FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<ApiResources>(new ApiResources(), c.Source.ApiResourcesId.ToString()));
      FieldAsync<ListGraphType<AmbientTypesType>>("AmbientTypes", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<AmbientTypes>(new AmbientTypes(), c.Source.AmbientTypeId.ToString()));
    }
  }
  public class MicroServiceConfigInputType : InputObjectGraphType
  {
    public MicroServiceConfigInputType()
    {
      Name = "MicroServiceConfigInput";
      Field<StringGraphType>("Name");
      Field<StringGraphType>("Ip");
      Field<IntGraphType>("Port");
      Field<StringGraphType>("Password");
      Field<StringGraphType>("MicroServiceId");
      Field<StringGraphType>("UserName");
      Field<StringGraphType>("ApiResourcesId");
      Field<StringGraphType>("AmbientTypeId");
    }
  }
}