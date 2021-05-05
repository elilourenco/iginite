using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientPostLogoutRedirectUrisType : ObjectGraphType<ClientPostLogoutRedirectUris> {
    public ClientPostLogoutRedirectUrisType () {
      Name = "ClientPostLogoutRedirectUris";
      Field (x => x.Id, nullable : true);
      Field (x => x.PostLogoutRedirectUri, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null :  new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientPostLogoutRedirectUrisInputType : InputObjectGraphType {
    public ClientPostLogoutRedirectUrisInputType () {
      Name = "ClientPostLogoutRedirectUrisInput";
      Field<StringGraphType> ("PostLogoutRedirectUri");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}