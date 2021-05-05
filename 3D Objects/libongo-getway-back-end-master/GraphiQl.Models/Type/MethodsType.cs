using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class MethodsType : ObjectGraphType<Methods>
  {
    public MethodsType()
    {
      Name = "Methods";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class MethodsInputType : InputObjectGraphType
  {
    public MethodsInputType()
    {
      Name = "MethodsInput";
      Field<StringGraphType>("Name");
    }
  }

}
