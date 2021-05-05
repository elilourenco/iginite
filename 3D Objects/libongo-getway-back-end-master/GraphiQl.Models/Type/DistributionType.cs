using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class DistributionType : ObjectGraphType<Distribution>
  {
    public DistributionType()
    {
         Name = "Distribution";
         Field(x => x.Id, nullable: true);
          Field(x => x.Title, nullable: true);FieldAsync<ListGraphType<DatasheetType>>("Datasheet", resolve : async c =>c.Source.DatasheetId == null?null :  new manipulacao().selectOne<Datasheet> (new Datasheet(),c.Source.DatasheetId.ToString())); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class DistributionInputType: InputObjectGraphType
    {
        public DistributionInputType()
        {
             Name = "DistributionInput";
             Field<StringGraphType>("Title");Field<StringGraphType>("DatasheetId");Field<DatasheetInputType>("Datasheet");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
