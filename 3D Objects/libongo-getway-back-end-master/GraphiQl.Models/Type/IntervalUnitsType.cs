using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class IntervalUnitsType : ObjectGraphType<IntervalUnits>
  {
    public IntervalUnitsType()
    {
         Name = "IntervalUnits";
         Field(x => x.Id, nullable: true);
          Field(x => x.Unit, nullable: true); Field(x => x.CodIntervalUnit, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class IntervalUnitsInputType: InputObjectGraphType
    {
        public IntervalUnitsInputType()
        {
             Name = "IntervalUnitsInput";
             Field<StringGraphType>("Unit");Field<StringGraphType>("CodIntervalUnit");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
