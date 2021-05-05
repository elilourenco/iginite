using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class AspNetUserClaimsType : ObjectGraphType<AspNetUserClaims>
  {
    public AspNetUserClaimsType()
    {
      Name = "AspNetUserClaims";
      Field(x => x.Id, nullable: true);
      FieldAsync<ListGraphType<AspNetUsersType>>("AspNetUsers", resolve: async c => c.Source.AspNetUsersId==null?null: new manipulacao().selectOne<AspNetUsers>(new AspNetUsers(), c.Source.AspNetUsersId.ToString())); 
      Field(x => x.ClaimType, nullable: true); 
      Field(x => x.ClaimValue, nullable: true);
    }
  }
  public class AspNetUserClaimsInputType : InputObjectGraphType
  {
    public AspNetUserClaimsInputType()
    {
      Name = "AspNetUserClaimsInput";
      Field<StringGraphType>("AspNetUsersId"); 
      Field<AspNetUsersInputType>("AspNetUsers");
      Field<StringGraphType>("ClaimType"); 
      Field<StringGraphType>("ClaimValue");
    }
  }

}
