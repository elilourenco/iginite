using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class QueueType : ObjectGraphType<Queue>
  {
    public QueueType()
    {
      Name = "Queue";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      FieldAsync<ListGraphType<RoutesType>>("Routes", resolve: async c => c.Source.IdRoute==null?null: new manipulacao().selectOne<Routes>(new Routes(), c.Source.IdRoute.ToString()));
    }
  }
  public class QueueInputType : InputObjectGraphType
  {
    public QueueInputType()
    {
      Name = "QueueInput";
      Field<StringGraphType>("Name"); 
      Field<StringGraphType>("IdRoute"); 
      Field<RoutesInputType>("Routes");
    }
  }

}
