using System;
using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ClientClientsType : ObjectGraphType<ClientClients> {
    public ClientClientsType () {
      Name = "ClientClients";
      Field (x => x.Id, nullable : true);
      Field (x => x.PersonId, nullable : true);
      Field (x => x.ClientId, nullable : true);
      Field (x => x.IsActive, nullable : true);
      //Field (x => x.CreationDate, nullable : true);
      FieldAsync<ListGraphType<ClientsType>> ("Clients", resolve : async c => c.Source.ClientId==null?null: new  manipulacao ().selectOne<Clients> (new Clients (), c.Source.ClientId.ToString ()));
      FieldAsync<ListGraphType<ClientClientsRoutesType>> ("ClientClientsRoutes", resolve : async c => c.Source.Id==null?null: new manipulacao ().selectOne<ClientClientsRoutes> (new ClientClientsRoutes (), c.Source.Id.ToString ()));
      FieldAsync<ListGraphType<PersonsType>> ("Persons", resolve : async c => c.Source.PersonId==null?null: new manipulacao ().selectOne<Persons> (new Persons (), c.Source.PersonId.ToString ()));
    }
  }
  public class ClientClientsInputType : InputObjectGraphType {
    public ClientClientsInputType () {
      Name = "ClientClientsInput";
      Field<StringGraphType> ("PersonId");
      Field<StringGraphType> ("ClientId");
      Field<BooleanGraphType> ("IsActive");
      Field<ClientsInputType> ("Clients");
      Field<PersonsInputType>("Persons");
      Field<statisticsClientClientInputType>("statisticsClientClient");      
    }
  }
}