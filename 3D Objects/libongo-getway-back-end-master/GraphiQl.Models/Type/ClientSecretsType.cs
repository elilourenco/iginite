using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientSecretsType : ObjectGraphType<ClientSecrets> {
    public ClientSecretsType () {
      Name = "ClientSecrets";
      Field (x => x.Id, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.Value, nullable : true);
      Field (x => x.Expiration, nullable : true);
      Field (x => x.Type, nullable : true);
      Field (x => x.Created, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId == null?null : new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
    }
  }
  public class ClientSecretsInputType : InputObjectGraphType {
    public ClientSecretsInputType () {
      Name = "ClientSecretsInput";
      Field<StringGraphType> ("Description");
      Field<StringGraphType> ("Value");
      Field<DateTimeGraphType> ("Expiration");
      Field<StringGraphType> ("Type");
      Field<DateTimeGraphType> ("Created");
      Field<IntGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
    }
  }

}