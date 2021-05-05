using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientScopesType : ObjectGraphType<ClientScopes> {
    public ClientScopesType () {
      Name = "ClientScopes";
      Field (x => x.Id, nullable : true);
      Field (x => x.Scope, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null : new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientScopesInputType : InputObjectGraphType {
    public ClientScopesInputType () {
      Name = "ClientScopesInput";
      Field<StringGraphType> ("Scope");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}