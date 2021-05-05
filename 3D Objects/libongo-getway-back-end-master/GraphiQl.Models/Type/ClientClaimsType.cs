using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientClaimsType : ObjectGraphType<ClientClaims> {
    public ClientClaimsType () {
      Name = "ClientClaims";
      Field (x => x.Id, nullable : true);
      Field (x => x.Type, nullable : true);
      Field (x => x.Value, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c => c.Source.ClientId==null?null: new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientClaimsInputType : InputObjectGraphType {
    public ClientClaimsInputType () {
      Name = "ClientClaimsInput";
      Field<StringGraphType> ("Type");
      Field<StringGraphType> ("Value");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}