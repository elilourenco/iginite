using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class RoutesCanalType : ObjectGraphType<RoutesCanal>
  {
    public RoutesCanalType()
    {
      Name = "RoutesCanal";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c => c.Source.RouteId==null?null: new manipulacao().selectOne<Routes>(new Routes(), c.Source.RouteId.ToString()));
      FieldAsync<ListGraphType<CanalType>>("Canal", resolve: async c => c.Source.CanalId==null?null: new manipulacao().selectOne<Canal>(new Canal(), c.Source.CanalId.ToString()));
      FieldAsync<ListGraphType<TypeReturnsType>>("TypeReturns", resolve: async c =>c.Source.TypeReturnId==null?null: new manipulacao().selectOne<TypeReturns>(new TypeReturns(), c.Source.TypeReturnId.ToString()));
    }
  }
  public class RoutesCanalInputType : InputObjectGraphType
  {
    public RoutesCanalInputType()
    {
      Name = "RoutesCanalInput";
      Field<StringGraphType>("RouteId");
      Field<RoutesInputType>("Routes");
      Field<StringGraphType>("CanalId");
      Field<StringGraphType>("TypeReturnId");
      Field<CanalInputType>("Canal");
    }
  }

}