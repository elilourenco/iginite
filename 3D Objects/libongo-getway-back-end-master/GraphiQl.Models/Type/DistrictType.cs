using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class DistrictType : ObjectGraphType<District> {
    public DistrictType () {
      Name = "District";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<CountyType>> ("County", resolve : async c => c.Source.CountyId == null?null : new manipulacao ().selectOne<County> (new County (), c.Source.CountyId.ToString ()));
      Field (x => x.DistrictCod, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class DistrictInputType : InputObjectGraphType {
    public DistrictInputType () {
      Name = "DistrictInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("CountyId");
      Field<CountyInputType> ("County");
      Field<StringGraphType> ("DistrictCod");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }

}