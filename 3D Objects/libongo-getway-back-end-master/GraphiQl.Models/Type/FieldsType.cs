using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class FieldsType : ObjectGraphType<Fields> {
    public FieldsType () {
      Name = "Fields";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<RoutesCanalType>> ("RoutesCanal", resolve : async c =>c.Source.RoutesCanalId == null?null : new manipulacao ().selectOne<RoutesCanal> (new RoutesCanal (), c.Source.RoutesCanalId.ToString ()));
    }
  }
  public class FieldsInputType : InputObjectGraphType {
    public FieldsInputType () {
      Name = "FieldsInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("RoutesCanalId");
      Field<RoutesInputType> ("RoutesCanal");
      Field<ListGraphType<RestrictionsInputType>> ("Restrictions");
    }
  }
}