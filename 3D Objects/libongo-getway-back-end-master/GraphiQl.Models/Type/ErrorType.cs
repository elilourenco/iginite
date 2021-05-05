using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ErrorType : ObjectGraphType<Error>
  {
    public ErrorType()
    {
         Name = "Error";
         Field(x => x.Id, nullable: true);
          Field(x => x.CodError, nullable: true); Field(x => x.Message, nullable: true); Field(x => x.Description, nullable: true);FieldAsync<ListGraphType<DatasheetType>>("Datasheet", resolve : async c =>c.Source.DatasheetId == null?null :  new manipulacao().selectOne<Datasheet> (new Datasheet(),c.Source.DatasheetId.ToString())); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class ErrorInputType: InputObjectGraphType
    {
        public ErrorInputType()
        {
             Name = "ErrorInput";
             Field<StringGraphType>("CodError");Field<StringGraphType>("Message");Field<StringGraphType>("Description");Field<StringGraphType>("DatasheetId");Field<DatasheetInputType>("Datasheet");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
