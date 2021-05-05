using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class CanalType : ObjectGraphType<Canal>
  {
    public CanalType()
    {
      Name = "Canal";
      Field(x => x.Id, nullable: true);
      Field(x => x.Designation, nullable: true);
    }
  }
  public class CanalInputType : InputObjectGraphType
  {
    public CanalInputType()
    {
      Name = "CanalInput";
      Field<StringGraphType>("Designation");
    }
  }
}