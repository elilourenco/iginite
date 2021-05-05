using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class RoutesTagsType : ObjectGraphType<RoutesTags> {
    public RoutesTagsType () {
      Name = "RoutesTags";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId==null?null: new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
      FieldAsync<ListGraphType<TagsType>> ("Tags", resolve : async c => c.Source.TagId==null?null: new manipulacao ().selectOne<Tags> (new Tags (), c.Source.TagId.ToString ()));
    }
  }
  public class RoutesTagsInputType : InputObjectGraphType {
    public RoutesTagsInputType () {
      Name = "RoutesTagsInput";
      Field<IntGraphType> ("RouteId");
      Field<RoutesInputType> ("Routes");
      Field<IntGraphType> ("TagId");
      Field<TagsInputType> ("Tags");
    }
  }

}