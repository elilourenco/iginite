using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiResourceScopesType : ObjectGraphType<ApiResourceScopes> {
    public ApiResourceScopesType () {
      Name = "ApiResourceScopes";
      Field (x => x.Id, nullable : true);
      Field (x => x.Scope, nullable : true);
      FieldAsync<ListGraphType<ApiResourcesType>> ("ApiResources", resolve : async c => c.Source.ApiResourceId == null?null : new manipulacao ().selectOne<ApiResources> (new ApiResources (), c.Source.ApiResourceId.ToString ()));
    }
  }
  public class ApiResourceScopesInputType : InputObjectGraphType {
    public ApiResourceScopesInputType () {
      Name = "ApiResourceScopesInput";
      Field<StringGraphType> ("Scope");
      Field<IntGraphType> ("ApiResourceId");
      Field<ApiResourcesInputType> ("ApiResources");
    }
  }

}