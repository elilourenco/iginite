using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class RoutesMethodsType : ObjectGraphType<RoutesMethods> {
    public RoutesMethodsType () {
      Name = "RoutesMethods";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<MethodsType>> ("Methods", resolve : async c =>c.Source.MethodId==null?null: new manipulacao ().selectOne<Methods> (new Methods (), c.Source.MethodId.ToString ()));
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c =>c.Source.RouteId==null?null: new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
    }
  }
  public class RoutesMethodsInputType : InputObjectGraphType {
    public RoutesMethodsInputType () {
      Name = "RoutesMethodsInput";
      Field<StringGraphType> ("MethodId");
      Field<MethodsInputType> ("Methods");
      Field<StringGraphType> ("RouteId");
      Field<RoutesInputType> ("Routes");
    }
  }

}