using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class RegionType : ObjectGraphType<Region> {
    public RegionType () {
      Name = "Region";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.RegionCode, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class RegionInputType : InputObjectGraphType {
    public RegionInputType () {
      Name = "RegionInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("RegionCode");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }
}