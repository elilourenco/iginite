using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientGrantTypesType : ObjectGraphType<ClientGrantTypes> {
    public ClientGrantTypesType () {
      Name = "ClientGrantTypes";
      Field (x => x.Id, nullable : true);
      Field (x => x.GrantType, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null :  new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientGrantTypesInputType : InputObjectGraphType {
    public ClientGrantTypesInputType () {
      Name = "ClientGrantTypesInput";
      Field<StringGraphType> ("GrantType");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}