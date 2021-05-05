using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiResourcesTagsType : ObjectGraphType<ApiResourcesTags> {
    public ApiResourcesTagsType () {
      Name = "ApiResourcesTags";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<ApiResourcesType>> ("ApiResources", resolve : async c => c.Source.ApiResourceId==null?null: new manipulacao ().selectOne<ApiResources> (new ApiResources (), c.Source.ApiResourceId.ToString ()));
      FieldAsync<ListGraphType<TagsType>> ("Tags", resolve : async c => c.Source.TagId==null?null: new manipulacao ().selectOne<Tags> (new Tags (), c.Source.TagId.ToString ()));
    }
  }
  public class ApiResourcesTagsInputType : InputObjectGraphType {
    public ApiResourcesTagsInputType () {
      Name = "ApiResourcesTagsInput";
      Field<IntGraphType> ("ApiResourceId");
      Field<ApiResourcesInputType> ("ApiResources");
      Field<IntGraphType> ("TagId");
      Field<TagsInputType> ("Tags");
    }
  }

}