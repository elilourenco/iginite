using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class MembersClientType : ObjectGraphType<MembersClient> {
    public MembersClientType () {
      Name = "MembersClient";
      Field (x => x.Id, nullable : true);
      Field (x => x.PersonsId, nullable : true);
      Field (x => x.PerfilMembersId, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c =>c.Source.ClientsId==null?null: new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientsId.ToString ()));
      FieldAsync<ListGraphType<PersonsType>> ("Persons", resolve : async c =>c.Source.PersonsId==null?null: new manipulacao ().selectOne<Persons> (new Persons (), c.Source.PersonsId.ToString ()));
      FieldAsync<ListGraphType<PerfilMembersType>> ("PerfilMembers", resolve : async c =>c.Source.PerfilMembersId==null?null: new manipulacao ().selectOne<PerfilMembers> (new PerfilMembers (), c.Source.PerfilMembersId.ToString ()));
           
    }
  }
    public class MembersClientInputType : InputObjectGraphType
    {
        public MembersClientInputType()
        {
            Name = "MembersClientInput";
            Field<StringGraphType>("PersonsId");
            Field<StringGraphType>("PerfilMembersId");
            Field<StringGraphType>("ClientsId");
            Field<ClientClientsInputType>("Clients");
            Field<PersonsInputType>("Persons");
            Field<PersonsInputType>("PerfilMembers");
            Field<AspNetUsersInputType>("AspNetUsers");    
        }
    }
}