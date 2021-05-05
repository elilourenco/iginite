using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class StatussType : ObjectGraphType<Statuss> {
    public StatussType () {
      Name = "Statuss";
      Field (x => x.Id, nullable : true);
      Field (x => x.Designation, nullable : true);
      Field (x => x.StatusCode, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      Field (x => x.Obs, nullable : true);
    }
  }
  public class StatussInputType : InputObjectGraphType {
    public StatussInputType () {
      Name = "StatussInput";
      Field<StringGraphType> ("Designation");
      Field<StringGraphType> ("StatusCode");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("Obs");
    }
  }

}