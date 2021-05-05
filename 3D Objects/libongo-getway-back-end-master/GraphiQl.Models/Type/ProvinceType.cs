using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ProvinceType : ObjectGraphType<Province> {
    public ProvinceType () {
      Name = "Province";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<RegionType>> ("Region", resolve : async c => c.Source.RegionId == null?null : new manipulacao ().selectOne<Region> (new Region (), c.Source.RegionId.ToString ()));
      FieldAsync<ListGraphType<CountryType>> ("Country", resolve : async c => c.Source.CountryId == null?null : new manipulacao ().selectOne<Country> (new Country (), c.Source.CountryId.ToString ()));
      Field (x => x.ProvinceCod, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class ProvinceInputType : InputObjectGraphType {
    public ProvinceInputType () {
      Name = "ProvinceInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("RegionId");
      Field<RegionInputType> ("Region");
      Field<StringGraphType> ("CountryId");
      Field<CountryInputType> ("Country");
      Field<StringGraphType> ("ProvinceCod");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }
}