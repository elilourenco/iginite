using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class MetricTypesType : ObjectGraphType<MetricTypes>
  {
    public MetricTypesType()
    {
         Name = "MetricTypes";
         Field(x => x.Id, nullable: true);
          Field(x => x.Type, nullable: true); Field(x => x.CodMetricType, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class MetricTypesInputType: InputObjectGraphType
    {
        public MetricTypesInputType()
        {
             Name = "MetricTypesInput";
             Field<StringGraphType>("Type");Field<StringGraphType>("CodMetricType");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
