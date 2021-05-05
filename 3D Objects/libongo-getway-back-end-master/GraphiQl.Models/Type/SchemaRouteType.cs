using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class SchemaRouteType : ObjectGraphType<SchemaRoute>
  {
    public SchemaRouteType()
    {
      Name = "SchemaRoute";
      Field(x => x.Id, nullable: true);
      FieldAsync<ListGraphType<SchemaGraphQType>>("SchemaGraphQ", resolve: async c => c.Source.SchemaGraphQId==null?null: new manipulacao().selectOne<SchemaGraphQ>(new SchemaGraphQ(), c.Source.SchemaGraphQId.ToString()));
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c => c.Source.RouteId==null?null: new manipulacao().selectOne<Routes>(new Routes(), c.Source.RouteId.ToString()));
      Field(x => x.Objecto, nullable: true);
      Field(x => x.ObjectoType, nullable: true);
    }
  }
  public class SchemaRouteInputType : InputObjectGraphType
  {
    public SchemaRouteInputType()
    {
      Name = "SchemaRouteInput";
      Field<StringGraphType>("SchemaGraphQId");
      //Field<SchemaGraphQInputType>("SchemaGraphQ");
      Field<StringGraphType>("RouteId");
      Field<RoutesInputType>("Routes");
      Field<StringGraphType>("Objecto");
      Field<StringGraphType>("ObjectoType");
    }
  }

}