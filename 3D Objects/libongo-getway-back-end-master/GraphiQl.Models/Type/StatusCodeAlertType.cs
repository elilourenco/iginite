using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class StatusCodeAlertType : ObjectGraphType<StatusCodeAlert>
  {
    public StatusCodeAlertType()
    {
         Name = "StatusCodeAlert";
         Field(x => x.Id, nullable: true);
         FieldAsync<ListGraphType<StatusCodeType>>("StatusCode", resolve : async c =>c.Source.StatusCodeId == null?null :  new manipulacao().selectOne<StatusCode> (new StatusCode(),c.Source.StatusCodeId.ToString()));FieldAsync<ListGraphType<AlertsType>>("Alerts", resolve : async c =>c.Source.AlertId == null?null :  new manipulacao().selectOne<Alerts> (new Alerts(),c.Source.AlertId.ToString())); Field(x => x.CodStatusCodeAlert, nullable: true); Field(x => x.CreationDate, nullable: true); Field(x => x.UpdateDate, nullable: true);
    }
  }
   public class StatusCodeAlertInputType: InputObjectGraphType
    {
        public StatusCodeAlertInputType()
        {
             Name = "StatusCodeAlertInput";
             Field<StringGraphType>("StatusCodeId");Field<StatusCodeInputType>("StatusCode");Field<StringGraphType>("AlertId");Field<AlertsInputType>("Alerts");Field<StringGraphType>("CodStatusCodeAlert");Field<DateTimeGraphType>("CreationDate");Field<DateTimeGraphType>("UpdateDate");
        }
    }

}
