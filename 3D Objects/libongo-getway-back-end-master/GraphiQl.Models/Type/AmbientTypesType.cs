using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class AmbientTypesType : ObjectGraphType<AmbientTypes>
  {
    public AmbientTypesType()
    {
      Name = "AmbientTypes";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class AmbientTypesInputType : InputObjectGraphType
  {
    public AmbientTypesInputType()
    {
      Name = "AmbientTypesInput";
      Field<StringGraphType>("Name");
    }
  }

}
