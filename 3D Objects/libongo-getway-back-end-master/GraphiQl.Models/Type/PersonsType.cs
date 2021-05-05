using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class PersonsType : ObjectGraphType<Persons>
  {
    public PersonsType()
    {
      Name = "Persons";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      Field(x => x.NIF, nullable: true);
      Field(x => x.MembersNumber, nullable: true);
      Field(x => x.Sigla, nullable: true);
      Field(x => x.RegistryCompanyNumber, nullable: true);
      FieldAsync<ListGraphType<PersonTypeType>>("PersonType", resolve: async c =>c.Source.PersonTypeId==null?null:  new manipulacao().selectOne<PersonType>(new PersonType(), c.Source.PersonTypeId.ToString()));
      Field(x => x.FilePath, nullable: true);
      FieldAsync<ListGraphType<ActivityCompanyType>>("ActivityCompany", resolve: async c =>c.Source.ActivityCompanyId==null?null:  new manipulacao().selectOne<ActivityCompany>(new ActivityCompany(), c.Source.ActivityCompanyId.ToString()));
      Field(x => x.CreationDate, nullable: true);
      Field(x => x.UpdateDate, nullable: true);
      FieldAsync<ListGraphType<ClientsType>>("Clients", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<Clients>(new Clients(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<ClientClientsType>>("ClientClients", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<ClientClients>(new ClientClients(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<MembersType>>("Members", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<Members>(new Members(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<MembersClientType>>("MembersClient", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<MembersClient>(new MembersClient(), c.Source.Id.ToString()));
      FieldAsync<ListGraphType<AspNetUsersType>>("AspNetUsers", resolve: async c =>c.Source.Id==null?null:  new manipulacao().selectOne<AspNetUsers>(new AspNetUsers(), c.Source.Id.ToString()));
    }
  }
  public class PersonsInputType : InputObjectGraphType
  {
    public PersonsInputType()
    {
      Name = "PersonsInput";
      Field<StringGraphType>("Name");
      Field<StringGraphType>("NIF");
      Field<IntGraphType>("MembersNumber");
      Field<StringGraphType>("Sigla");
      Field<StringGraphType>("RegistryCompanyNumber");
      Field<StringGraphType>("PersonTypeId");
      //Field<PersonTypeInputType>("PersonType");
      Field<StringGraphType>("FilePath");
      Field<StringGraphType>("ActivityCompanyId");
      //Field<ActivityCompanyInputType>("ActivityCompany");
      Field<DateTimeGraphType>("CreationDate");
      Field<DateTimeGraphType>("UpdateDate");
    }
  }

}