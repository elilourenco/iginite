using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class SpecialRoutesType : ObjectGraphType<SpecialRoutes> {
    public SpecialRoutesType () {
      Name = "SpecialRoutes";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<AspNetUsersType>> ("AspNetUsers", resolve : async c => c.Source.AspnetusersId == null?null : new manipulacao ().selectOne<AspNetUsers> (new AspNetUsers (), c.Source.AspnetusersId.ToString ()));
    }
  }
  public class SpecialRoutesInputType : InputObjectGraphType {
    public SpecialRoutesInputType () {
      Name = "SpecialRoutesInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("AspnetusersId");
      Field<AspNetUsersInputType> ("AspNetUsers");
    }
  }

}