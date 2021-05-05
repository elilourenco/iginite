using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiScopeClaimsType : ObjectGraphType<ApiScopeClaims> {
    public ApiScopeClaimsType () {
      Name = "ApiScopeClaims";
      Field (x => x.Id, nullable : true);
      Field (x => x.Type, nullable : true);
      FieldAsync<ListGraphType<ApiScopesType>> ("ApiScopes", resolve : async c => c.Source.ScopeId == null?null : new manipulacao ().selectOne<ApiScopes> (new ApiScopes (), c.Source.ScopeId.ToString ()));
    }
  }
  public class ApiScopeClaimsInputType : InputObjectGraphType {
    public ApiScopeClaimsInputType () {
      Name = "ApiScopeClaimsInput";
      Field<StringGraphType> ("Type");
      Field<IntGraphType> ("ScopeId");
      Field<ApiScopesInputType> ("ApiScopes");
    }
  }

}