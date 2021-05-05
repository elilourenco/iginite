using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class LoginType : ObjectGraphType<Login> {
    public LoginType () {
      Name = "Login";
      Field (x => x.Id, nullable : true);
      Field (x => x.Email, nullable : true);
      Field (x => x.PasswordHash, nullable : true);
      Field (x => x.UserName, nullable : true);
      Field (x => x.token, nullable : true);
      Field (x => x.Role, nullable : true);
      Field (x => x.message, nullable : true);
      Field (x => x.Domain, nullable : true);
      Field (x => x.City, nullable : true);
      Field (x => x.Company, nullable : true);
      Field (x => x.Country, nullable : true);
      Field (x => x.TelephoneNumber, nullable : true);
      Field (x => x.LastName, nullable : true);
      Field (x => x.FirstName, nullable : true);

      FieldAsync<ListGraphType<AspNetUsersType>>("AspNetUsers", resolve: async c => c.Source.Id==null?null: new manipulacao().selectOne<AspNetUsers>(new AspNetUsers(), c.Source.Id.ToString()));
    }
  }
  public class LoginInputType : InputObjectGraphType {
    public LoginInputType () {
      
      Name = "LoginInput";
      Field<StringGraphType> ("Domain");
      Field<StringGraphType> ("Email");
      Field<StringGraphType> ("PasswordHash");
      Field<StringGraphType> ("UserName");
    }
  }
}