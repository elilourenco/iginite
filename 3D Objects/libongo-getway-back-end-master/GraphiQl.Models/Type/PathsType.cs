using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class PathsType : ObjectGraphType<Paths>
  {
    public PathsType()
    {
      Name = "Paths";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      Field(x => x.RouteId, nullable: true);
    }
  }
  public class PathsInputType : InputObjectGraphType
  {
    public PathsInputType()
    {
      Name = "PathsInput";
      Field<StringGraphType>("Name");
      Field<StringGraphType>("RouteId");
    }
  }

}
