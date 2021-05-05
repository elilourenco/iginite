using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class WorkType : ObjectGraphType<Work>
  {
    public WorkType()
    {
         Name = "Work";
         Field(x => x.Id, nullable: true);
          Field(x => x.Operacoes, nullable: true); Field(x => x.Funcionalidades, nullable: true); Field(x => x.Methods, nullable: true); Field(x => x.RestFullEnPoint, nullable: true);FieldAsync<ListGraphType<DatasheetType>>("Datasheet", resolve : async c =>c.Source.DatasheetId == null?null :  new manipulacao().selectOne<Datasheet> (new Datasheet(),c.Source.DatasheetId.ToString())); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class WorkInputType: InputObjectGraphType
    {
        public WorkInputType()
        {
             Name = "WorkInput";
             Field<StringGraphType>("Operacoes");Field<StringGraphType>("Funcionalidades");Field<StringGraphType>("Methods");Field<StringGraphType>("RestFullEnPoint");Field<StringGraphType>("DatasheetId");Field<DatasheetInputType>("Datasheet");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
