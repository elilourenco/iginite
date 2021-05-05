using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientRedirectUrisType : ObjectGraphType<ClientRedirectUris> {
    public ClientRedirectUrisType () {
      Name = "ClientRedirectUris";
      Field (x => x.Id, nullable : true);
      Field (x => x.RedirectUri, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null :  new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientRedirectUrisInputType : InputObjectGraphType {
    public ClientRedirectUrisInputType () {
      Name = "ClientRedirectUrisInput";
      Field<StringGraphType> ("RedirectUri");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}