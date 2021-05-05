using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class MetricConditionsType : ObjectGraphType<MetricConditions>
  {
    public MetricConditionsType()
    {
         Name = "MetricConditions";
         Field(x => x.Id, nullable: true);
          Field(x => x.Condition, nullable: true); Field(x => x.CodMetricCondition, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class MetricConditionsInputType: InputObjectGraphType
    {
        public MetricConditionsInputType()
        {
             Name = "MetricConditionsInput";
             Field<StringGraphType>("Condition");Field<StringGraphType>("CodMetricCondition");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
