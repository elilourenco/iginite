using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class UserProfileType : ObjectGraphType<UserProfile> {
    public UserProfileType () {
      Name = "UserProfile";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<AspNetUsersType>> ("AspNetUsers", resolve : async c => c.Source.AspNetUserId==null?null:  new manipulacao ().selectOne<AspNetUsers> (new AspNetUsers (), c.Source.AspNetUserId.ToString ()));
      FieldAsync<ListGraphType<AspNetRolesType>> ("AspNetRoles", resolve : async c => c.Source.AspNetRolesId==null?null:  new manipulacao ().selectOne<AspNetRoles> (new AspNetRoles (), c.Source.AspNetRolesId.ToString ()));
    }
  }
  public class UserProfileInputType : InputObjectGraphType {
    public UserProfileInputType () {
      Name = "UserProfileInput";
      Field<StringGraphType> ("AspNetUserId");
      Field<AspNetUsersInputType> ("AspNetUsers");
      Field<StringGraphType> ("AspNetRolesId");
      Field<AspNetRolesInputType> ("AspNetRoles");
    }
  }

}