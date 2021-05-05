using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class AspNetRolesType : ObjectGraphType<AspNetRoles> {
    public AspNetRolesType () {
      Name = "AspNetRoles";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.NormalizedName, nullable : true);
      Field (x => x.ConcurrencyStamp, nullable : true);
    }
  }
  public class AspNetRolesInputType : InputObjectGraphType {
    public AspNetRolesInputType () {
      Name = "AspNetRolesInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("NormalizedName");
      Field<StringGraphType> ("ConcurrencyStamp");
    }
  }

}