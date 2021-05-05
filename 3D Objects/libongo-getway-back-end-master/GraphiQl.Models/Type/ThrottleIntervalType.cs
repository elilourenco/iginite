using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ThrottleIntervalType : ObjectGraphType<ThrottleInterval>
  {
    public ThrottleIntervalType()
    {
         Name = "ThrottleInterval";
         Field(x => x.Id, nullable: true);
          Field(x => x.IntervalValue, nullable: true);FieldAsync<ListGraphType<ApiResourcesType>>("ApiResources", resolve : async c =>c.Source.ApiResourceId == null?null :  new manipulacao().selectOne<ApiResources> (new ApiResources(),c.Source.ApiResourceId.ToString())); Field(x => x.CodThrottleInterval, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class ThrottleIntervalInputType: InputObjectGraphType
    {
        public ThrottleIntervalInputType()
        {
             Name = "ThrottleIntervalInput";
             Field<IntGraphType>("IntervalValue");Field<StringGraphType>("ApiResourceId");Field<ApiResourcesInputType>("ApiResources");Field<StringGraphType>("CodThrottleInterval");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
