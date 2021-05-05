using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ServiceType : ObjectGraphType<Service>
  {
    public ServiceType()
    {
      Name = "Service";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
    }
  }
  public class ServiceInputType : InputObjectGraphType
  {
    public ServiceInputType()
    {
      Name = "ServiceInput";
      Field<StringGraphType>("Name");
    }
  }
}
