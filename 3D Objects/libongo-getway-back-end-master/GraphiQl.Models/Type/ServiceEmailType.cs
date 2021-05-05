using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ServiceEmailType : ObjectGraphType<ServiceEmail> {
    public ServiceEmailType () {
      Name = "ServiceEmail";
      Field (x => x.Id, nullable : true);
      Field (x => x.Port, nullable : true);
      Field (x => x.Host, nullable : true);
      Field (x => x.Email, nullable : true);
      Field (x => x.Password, nullable : true);
    }
  }
  public class ServiceEmailInputType : InputObjectGraphType {
    public ServiceEmailInputType () {
      Name = "ServiceEmailInput";
      Field<IntGraphType> ("Port");
      Field<StringGraphType> ("Host");
      Field<StringGraphType> ("Email");
      Field<StringGraphType> ("Password");
    }
  }

}