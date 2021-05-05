using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ProtocolsType : ObjectGraphType<Protocols>
  {
    public ProtocolsType()
    {
      Name = "Protocols";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class ProtocolsInputType : InputObjectGraphType
  {
    public ProtocolsInputType()
    {
      Name = "ProtocolsInput";
      Field<StringGraphType>("Name");
    }
  }
}