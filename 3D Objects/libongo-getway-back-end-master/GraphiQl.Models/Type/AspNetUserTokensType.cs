using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class AspNetUserTokensType : ObjectGraphType<AspNetUserTokens> {
    public AspNetUserTokensType () {
      Name = "AspNetUserTokens";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<AspNetUsersType>> ("AspNetUsers", resolve : async c => c.Source.AspNetUsersId==null?null:  new manipulacao ().selectOne<AspNetUsers> (new AspNetUsers (), c.Source.AspNetUsersId.ToString ()));
      Field (x => x.LoginProvider, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.Value, nullable : true);
    }
  }
  public class AspNetUserTokensInputType : InputObjectGraphType {
    public AspNetUserTokensInputType () {
      Name = "AspNetUserTokensInput";
      Field<StringGraphType> ("AspNetUsersId");
      Field<AspNetUsersInputType> ("AspNetUsers");
      Field<StringGraphType> ("LoginProvider");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("Value");
    }
  }

}