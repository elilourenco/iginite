using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class StatusCodeType : ObjectGraphType<StatusCode>
  {
    public StatusCodeType()
    {
         Name = "StatusCode";
         Field(x => x.Id, nullable: true);
          Field(x => x.Code, nullable: true); Field(x => x.CodStatusCode, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class StatusCodeInputType: InputObjectGraphType
    {
        public StatusCodeInputType()
        {
             Name = "StatusCodeInput";
             Field<StringGraphType>("Code");Field<StringGraphType>("CodStatusCode");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
