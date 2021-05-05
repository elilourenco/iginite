using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class HeadersRoutesType : ObjectGraphType<HeadersRoutes> {
    public HeadersRoutesType () {
      Name = "HeadersRoutes";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<HeadersType>> ("Headers", resolve : async c =>c.Source.HeaderId == null?null : new manipulacao ().selectOne<Headers> (new Headers (), c.Source.HeaderId.ToString ()));
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c =>c.Source.RouteId == null?null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
    }
  }
  public class HeadersRoutesInputType : InputObjectGraphType {
    public HeadersRoutesInputType () {
      Name = "HeadersRoutesInput";
      Field<IntGraphType> ("HeaderId");
      Field<HeadersInputType> ("Headers");
      Field<IntGraphType> ("RouteId");
      Field<RoutesInputType> ("Routes");
    }
  }

}