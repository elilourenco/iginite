using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ApiScopePropertiesType : ObjectGraphType<ApiScopeProperties> {
    public ApiScopePropertiesType () {
      Name = "ApiScopeProperties";
      Field (x => x.Id, nullable : true);
      Field (x => x.Key, nullable : true);
      Field (x => x.Value, nullable : true);
      FieldAsync<ListGraphType<ApiScopesType>> ("ApiScopes", resolve : async c => c.Source.ScopeId==null?null: new manipulacao ().selectOne<ApiScopes> (new ApiScopes (), c.Source.ScopeId.ToString ()));
    }
  }
  public class ApiScopePropertiesInputType : InputObjectGraphType {
    public ApiScopePropertiesInputType () {
      Name = "ApiScopePropertiesInput";
      Field<StringGraphType> ("Key");
      Field<StringGraphType> ("Value");
      Field<IntGraphType> ("ScopeId");
      Field<ApiScopesInputType> ("ApiScopes");
    }
  }

}