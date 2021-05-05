using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class RoutesType : ObjectGraphType<Routes>
  {
    public RoutesType()
    {
      Name = "Routes";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      Field(x => x.ApiResourceId, nullable: true);
      FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve: async c => c.Source.ApiResourceId==null?null:  new manipulacao().selectOne<ApiResources>(new ApiResources(), c.Source.ApiResourceId.ToString()));
      Field(x => x.HTTPSRedirectStatusCode, nullable: true);
      Field(x => x.RegexPriority, nullable: true);
      Field(x => x.PathHandling, nullable: true);
      Field(x => x.StripPath, nullable: true);
      Field(x => x.PreserveHost, nullable: true);
      Field(x => x.MicroServiceTypeId, nullable: true);
      Field(x => x.SubCategoryRoutesId, nullable: true);
      FieldAsync<ListGraphType<PathsType>>("Paths", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<Paths>(new Paths(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<MethodsType>>("Methods", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<Methods>(new Methods(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<HostsType>>("Hosts", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<Hosts>(new Hosts(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<MicroServiceTypeType>>("MicroServiceType", resolve: async c => c.Source.MicroServiceTypeId==null?null: new manipulacao().selectOne<MicroServiceType>(new MicroServiceType(), c.Source.MicroServiceTypeId.ToString()));
      FieldAsync<ListGraphType<SubCategoryRoutesType>>("SubCategoryRoutes", resolve: async c => c.Source.SubCategoryRoutesId==null?null: new manipulacao().selectOne<SubCategoryRoutes>(new SubCategoryRoutes(), c.Source.SubCategoryRoutesId.ToString()));
      FieldAsync<ListGraphType<RoutesMethodsType>>("RoutesMethods", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<RoutesMethods>(new RoutesMethods(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<SchemaRouteType>>("SchemaRoute", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<SchemaRoute>(new SchemaRoute(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<RoutesCanalType>>("RoutesCanal", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<RoutesCanal>(new RoutesCanal(), c.Source.Id.ToString()));    
      FieldAsync<ListGraphType<AlertsType>>("Alerts", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<Alerts>(new Alerts(), c.Source.Id.ToString()));        
    }
  }
  public class RoutesInputType : InputObjectGraphType
  {
    public RoutesInputType()
    {
      Name = "RoutesInput";
      Field<StringGraphType>("Id");
      Field<StringGraphType>("Name");
      Field<StringGraphType>("ApiResourceId");
      Field<ApiResourcesInputType>("ApiResources");
      Field<IntGraphType>("HTTPSRedirectStatusCode");
      Field<BooleanGraphType>("RegexPriority");
      Field<StringGraphType>("PathHandling");
      Field<BooleanGraphType>("StripPath");
      Field<BooleanGraphType>("PreserveHost");
      Field<StringGraphType>("MicroServiceTypeId");
      Field<StringGraphType>("SubCategoryRoutesId");
      //Field<ListGraphType<SchemaRouteInputType>> ("SchemaRoute");
      Field<ListGraphType<RoutesCanalInputType>> ("RoutesCanal");
    }
  }
}