using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientIdPRestrictionsType : ObjectGraphType<ClientIdPRestrictions> {
    public ClientIdPRestrictionsType () {
      Name = "ClientIdPRestrictions";
      Field (x => x.Id, nullable : true);
      Field (x => x.Provider, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null :  new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientIdPRestrictionsInputType : InputObjectGraphType {
    public ClientIdPRestrictionsInputType () {
      Name = "ClientIdPRestrictionsInput";
      Field<StringGraphType> ("Provider");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}