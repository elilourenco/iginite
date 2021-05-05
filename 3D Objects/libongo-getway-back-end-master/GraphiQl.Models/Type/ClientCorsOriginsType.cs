using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientCorsOriginsType : ObjectGraphType<ClientCorsOrigins> {
    public ClientCorsOriginsType () {
      Name = "ClientCorsOrigins";
      Field (x => x.Id, nullable : true);
      Field (x => x.Origin, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c => c.Source.ClientId == null?null : new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientCorsOriginsInputType : InputObjectGraphType {
    public ClientCorsOriginsInputType () {
      Name = "ClientCorsOriginsInput";
      Field<StringGraphType> ("Origin");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}