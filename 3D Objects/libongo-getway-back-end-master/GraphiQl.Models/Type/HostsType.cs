using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class HostsType : ObjectGraphType<Hosts>
  {
    public HostsType()
    {
      Name = "Hosts";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c =>c.Source.RouteId == null?null :  new manipulacao().selectOne<Routes>(new Routes(), c.Source.RouteId.ToString()));
    }
  }
  public class HostsInputType : InputObjectGraphType
  {
    public HostsInputType()
    {
      Name = "HostsInput";
      Field<StringGraphType>("Name");
      Field<StringGraphType>("RouteId");
      Field<RoutesInputType>("Routes");
    }
  }

}