using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class AspNetUsersType : ObjectGraphType<AspNetUsers>
  {
    public AspNetUsersType()
    {
      Name = "AspNetUsers";
      Field(x => x.Id, nullable: true);
      Field(x => x.UserName, nullable: true);
      Field(x => x.NormalizedUserName, nullable: true);
      Field(x => x.Email, nullable: true);
      Field(x => x.NormalizedEmail, nullable: true);
      Field(x => x.EmailConfirmed, nullable: true);
      Field(x => x.PasswordHash, nullable: true);
      Field(x => x.SecurityStamp, nullable: true);
      Field(x => x.ConcurrencyStamp, nullable: true);
      Field(x => x.PhoneNumber, nullable: true);
      Field(x => x.PhoneNumberConfirmed, nullable: true);
      Field(x => x.TwoFactorEnabled, nullable: true);
      Field(x => x.LockoutEnd, nullable: true);
      Field(x => x.LockoutEnabled, nullable: true);
      Field(x => x.AccessFailedCount, nullable: true);
      Field(x => x.PersonsId, nullable: true);
      FieldAsync<ListGraphType<PersonsType>>("Persons", resolve: async c => c.Source.PersonsId==null?null:  new manipulacao().selectOne<Persons>(new Persons(), c.Source.PersonsId.ToString()));
      FieldAsync<ListGraphType<AspNetUserRolesType>>("AspNetUserRoles", resolve: async c => c.Source.Id==null?null:  new manipulacao().selectOne<AspNetUserRoles>(new AspNetUserRoles(), c.Source.Id.ToString()));
    }
  }
  public class AspNetUsersInputType : InputObjectGraphType
  {
    public AspNetUsersInputType()
    {
      Name = "AspNetUsersInput";
      Field<StringGraphType>("PersonsId");
      Field<StringGraphType>("UserName");
      Field<StringGraphType>("NormalizedUserName");
      Field<StringGraphType>("Email");
      Field<StringGraphType>("NormalizedEmail");
      Field<BooleanGraphType>("EmailConfirmed");
      Field<StringGraphType>("PasswordHash");
      Field<StringGraphType>("SecurityStamp");
      Field<StringGraphType>("ConcurrencyStamp");
      Field<StringGraphType>("PhoneNumber");
      Field<BooleanGraphType>("PhoneNumberConfirmed");
      Field<BooleanGraphType>("TwoFactorEnabled");
      Field<StringGraphType>("LockoutEnd");
      Field<BooleanGraphType>("LockoutEnabled");
      Field<IntGraphType>("AccessFailedCount");
    }
  }
}