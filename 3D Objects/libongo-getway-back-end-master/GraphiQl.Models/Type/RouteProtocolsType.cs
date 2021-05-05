using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class RouteProtocolsType : ObjectGraphType<RouteProtocols>
  {
    public RouteProtocolsType()
    {
      Name = "RouteProtocols";
      Field(x => x.Id, nullable: true);
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c => c.Source.RouteId==null?null: new manipulacao().selectOne<Routes>(new Routes(), c.Source.RouteId.ToString()));
      FieldAsync<ListGraphType<ProtocolsType>>("Protocols", resolve: async c => c.Source.ProtocolId==null?null: new manipulacao().selectOne<Protocols>(new Protocols(), c.Source.ProtocolId.ToString()));
    }
  }
  public class RouteProtocolsInputType : InputObjectGraphType
  {
    public RouteProtocolsInputType()
    {
      Name = "RouteProtocolsInput";
      Field<StringGraphType>("RouteId");
      Field<RoutesInputType>("Routes");
      Field<StringGraphType>("ProtocolId");
      Field<ProtocolsInputType>("Protocols");
    }
  }

}