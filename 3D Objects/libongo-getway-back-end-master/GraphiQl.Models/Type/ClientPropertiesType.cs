using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientPropertiesType : ObjectGraphType<ClientProperties> {
    public ClientPropertiesType () {
      Name = "ClientProperties";
      Field (x => x.Id, nullable : true);
      Field (x => x.Key, nullable : true);
      Field (x => x.Value, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null :  new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientPropertiesInputType : InputObjectGraphType {
    public ClientPropertiesInputType () {
      Name = "ClientPropertiesInput";
      Field<StringGraphType> ("Key");
      Field<StringGraphType> ("Value");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}