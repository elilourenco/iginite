using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class PerfilClientType : ObjectGraphType<PerfilClient> {
          public PerfilClientType () {
               Name = "PerfilClient";
               Field (x => x.Id, nullable : true);
               Field(x => x.ClientId, nullable: true);
               FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c => c.Source.ClientId == null?null : new manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
               FieldAsync<ListGraphType<PerfilMembersType>> ("PerfilMembers", resolve : async c => c.Source.PerfilMembersId == null?null : new manipulacao ().selectOne<PerfilMembers> (new PerfilMembers (), c.Source.PerfilMembersId.ToString ()));
          }
     }
     public class PerfilClientInputType : InputObjectGraphType {
          public PerfilClientInputType () {
               Name = "PerfilClientInput";
               Field<StringGraphType> ("ClientId");
               Field<StringGraphType> ("PerfilMembersId");
          }
     }
}