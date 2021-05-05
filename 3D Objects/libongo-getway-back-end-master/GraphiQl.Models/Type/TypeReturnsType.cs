using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class TypeReturnsType : ObjectGraphType<TypeReturns>
  {
    public TypeReturnsType()
    {
      Name = "TypeReturns";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class TypeReturnsInputType : InputObjectGraphType
  {
    public TypeReturnsInputType()
    {
      Name = "TypeReturnsInput";
      Field<StringGraphType>("Name");
    }
  }

}
