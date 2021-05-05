using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class RestrictionsType : ObjectGraphType<Restrictions> {
    public RestrictionsType () {
      Name = "Restrictions";
      Field (x => x.Id, nullable : true);
      Field (x => x.ClientClientsRoutesId, nullable : true);
      Field (x => x.FieldsId, nullable : true);
      FieldAsync<ListGraphType<ClientClientsRoutesType>> ("MembersRoutes", resolve : async c => c.Source.ClientClientsRoutesId == null?null : new manipulacao ().selectOne<ClientClientsRoutes> (new ClientClientsRoutes (), c.Source.ClientClientsRoutesId.ToString ()));
      FieldAsync<ListGraphType<FieldsType>> ("Fields", resolve : async c => c.Source.FieldsId==null?null: new manipulacao ().selectOne<Fields> (new Fields (), c.Source.FieldsId.ToString ()));
    }
  }
  public class RestrictionsInputType : InputObjectGraphType {
    public RestrictionsInputType () {
      Name = "RestrictionsInput";
      Field<StringGraphType> ("FieldsId");
      Field<StringGraphType> ("ClientClientsRoutesId");
    }
  }
}