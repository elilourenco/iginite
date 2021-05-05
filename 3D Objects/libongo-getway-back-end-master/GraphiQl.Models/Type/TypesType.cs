using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class TypesType : ObjectGraphType<Types>
  {
    public TypesType()
    {
      Name = "Types";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class TypesInputType : InputObjectGraphType
  {
    public TypesInputType()
    {
      Name = "TypesInput";
      Field<StringGraphType>("Name");
    }
  }

}
