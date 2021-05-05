using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class IdentityResourceClaimsType : ObjectGraphType<IdentityResourceClaims> {
    public IdentityResourceClaimsType () {
      Name = "IdentityResourceClaims";
      Field (x => x.Id, nullable : true);
      Field (x => x.Type, nullable : true);
      FieldAsync<ListGraphType<IdentityResourcesType>> ("IdentityResources", resolve : async c =>c.Source.IdentityResourceId == null?null : new manipulacao ().selectOne<IdentityResources> (new IdentityResources (), c.Source.IdentityResourceId.ToString ()));
    }
  }
  public class IdentityResourceClaimsInputType : InputObjectGraphType {
    public IdentityResourceClaimsInputType () {
      Name = "IdentityResourceClaimsInput";
      Field<StringGraphType> ("Type");
      Field<IntGraphType> ("IdentityResourceId");
      Field<IdentityResourcesInputType> ("IdentityResources");
    }
  }

}