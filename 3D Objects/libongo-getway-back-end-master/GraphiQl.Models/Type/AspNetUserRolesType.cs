using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class AspNetUserRolesType : ObjectGraphType<AspNetUserRoles> {
    public AspNetUserRolesType () {
      Name = "AspNetUserRoles";
      Field (x => x.AspNetUserId, nullable : true);
      Field (x => x.AspNetRoleId, nullable : true);
      FieldAsync<ListGraphType<AspNetUsersType>> ("AspNetUsers", resolve : async c => c.Source.AspNetUserId==null?null:  new manipulacao ().selectOne<AspNetUsers> (new AspNetUsers (), c.Source.AspNetUserId.ToString ()));
      FieldAsync<ListGraphType<AspNetRolesType>> ("AspNetRoles", resolve : async c => c.Source.AspNetRoleId==null?null:  new manipulacao ().selectOne<AspNetRoles> (new AspNetRoles (), c.Source.AspNetRoleId.ToString ()));
    }
  }
  public class AspNetUserRolesInputType : InputObjectGraphType {
    public AspNetUserRolesInputType () {
      Name = "AspNetUserRolesInput";
      Field<StringGraphType> ("AspNetUserId");
      Field<AspNetUsersInputType> ("AspNetUsers");
      Field<StringGraphType> ("AspNetRoleId");
      Field<AspNetRolesInputType> ("AspNetRole");
    }
  }

}