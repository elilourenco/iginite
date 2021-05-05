using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class PathsRoutesType : ObjectGraphType<PathsRoutes> {
    public PathsRoutesType () {
      Name = "PathsRoutes";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<PathsType>> ("Paths", resolve : async c =>c.Source.PathId==null?null:  new manipulacao ().selectOne<Paths> (new Paths (), c.Source.PathId.ToString ()));
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c =>c.Source.RouteId==null?null:  new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
    }
  }
  public class PathsRoutesInputType : InputObjectGraphType {
    public PathsRoutesInputType () {
      Name = "PathsRoutesInput";
      Field<IntGraphType> ("PathId");
      Field<PathsInputType> ("Paths");
      Field<IntGraphType> ("RouteId");
      Field<RoutesInputType> ("Routes");
    }
  }

}