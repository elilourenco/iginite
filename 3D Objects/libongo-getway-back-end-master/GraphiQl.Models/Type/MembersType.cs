using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class MembersType : ObjectGraphType<Members> {
    public MembersType () {
      Name = "Members";
      Field (x => x.Id, nullable : true);
      Field (x => x.PersonsId, nullable : true);
      FieldAsync<ListGraphType<PersonsType>> ("Persons", resolve : async c =>  c.Source.PersonsId==null?null:  new manipulacao ().selectOne<Persons>  (new Persons (),  c.Source.PersonsId.ToString ()));
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientId==null?null: new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
      FieldAsync<ListGraphType<PerfilMembersType>> ("PerfilMembers", resolve : async c =>c.Source.PerfilMembersId==null?null: new manipulacao ().selectOne<PerfilMembers> (new PerfilMembers (), c.Source.PerfilMembersId.ToString ()));
    }
  }
  public class MembersInputType : InputObjectGraphType {
    public MembersInputType () {
      Name = "MembersInput";
      Field<StringGraphType> ("PersonsId");
      Field<StringGraphType> ("ClientId");
      Field<ClientsInputType> ("Clients");
      Field<PersonsInputType> ("Persons");
      Field<PersonsInputType> ("PerfilMembers");
    }
  }

}