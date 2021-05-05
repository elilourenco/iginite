using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientClientsRoutesType : ObjectGraphType<ClientClientsRoutes> {
    public ClientClientsRoutesType () {
      Name = "ClientClientsRoutes";
      Field (x => x.Id, nullable : true);
      FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId==null?null: new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
      FieldAsync<ListGraphType<ClientClientsType>> ("ClientClients", resolve : async c => c.Source.ClientClientsId==null?null: new manipulacao ().selectOne<ClientClients> (new ClientClients (), c.Source.ClientClientsId.ToString ()));
      FieldAsync<ListGraphType<RestrictionsType>> ("Restrictions", resolve : async c => c.Source.Id==null?null: new manipulacao ().selectOne<Restrictions> (new Restrictions (), c.Source.Id.ToString ()));
    }
  }
  public class ClientClientsRoutesInputType : InputObjectGraphType {
    public ClientClientsRoutesInputType () {
      Name = "ClientClientsRoutesInput";
      Field<StringGraphType> ("RouteId");
      Field<RoutesInputType> ("Routes");
      Field<StringGraphType> ("ClientClientsId");
      Field<ClientClientsInputType> ("ClientClients");
    }
  }
}