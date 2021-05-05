using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class AspNetRoleClaimsType : ObjectGraphType<AspNetRoleClaims> {
    public AspNetRoleClaimsType () {
      Name = "AspNetRoleClaims";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<AspNetRolesType>> ("AspNetRoles", resolve : async c => c.Source.RoleId==null?null: new manipulacao ().selectOne<AspNetRoles> (new AspNetRoles (), c.Source.RoleId.ToString ()));
      Field (x => x.ClaimType, nullable : true);
      Field (x => x.ClaimValue, nullable : true);
    }
  }
  public class AspNetRoleClaimsInputType : InputObjectGraphType {
    public AspNetRoleClaimsInputType () {
      Name = "AspNetRoleClaimsInput";
      Field<StringGraphType> ("RoleId");
      Field<AspNetRolesInputType> ("AspNetRoles");
      Field<StringGraphType> ("ClaimType");
      Field<StringGraphType> ("ClaimValue");
    }
  }

}