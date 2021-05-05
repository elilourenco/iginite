using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class PersonTypeType : ObjectGraphType<PersonType>
  {
    public PersonTypeType()
    {
      Name = "PersonType";
      Field(x => x.Id, nullable: true);
      Field(x => x.Designation, nullable: true);
    }
  }
  public class PersonTypeInputType : InputObjectGraphType
  {
    public PersonTypeInputType()
    {
      Name = "PersonTypeInput";
      Field<StringGraphType>("Designation");
    }
  }

}
