using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class CountryType : ObjectGraphType<Country> {
    public CountryType () {
      Name = "Country";
      Field (x => x.Id, nullable : true);
      Field (x => x.CountryCod, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<RegionType>> ("Region", resolve : async c => c.Source.RegionId == null?null : new manipulacao ().selectOne<Region> (new Region (), c.Source.RegionId.ToString ()));
      FieldAsync<ListGraphType<ContinentType>> ("Continent", resolve : async c => c.Source.ContinentId == null?null : new manipulacao ().selectOne<Continent> (new Continent (), c.Source.ContinentId.ToString ()));
      Field (x => x.CodeISO, nullable : true);
      Field (x => x.ImagePath, nullable : true);
      FieldAsync<ListGraphType<ProvinceType>> ("Province", resolve : async c => c.Source.Id == null?null : new manipulacao ().selectOne<Province> (new Province (), c.Source.Id.ToString ()));
    }
  }
  public class CountryInputType : InputObjectGraphType {
    public CountryInputType () {
      Name = "CountryInput";
      Field<StringGraphType> ("CountryCod");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("RegionId");
      Field<RegionInputType> ("Region");
      Field<StringGraphType> ("ContinentId");
      Field<ContinentInputType> ("Continent");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
      Field<StringGraphType> ("CodeISO");
      Field<StringGraphType> ("ImagePath");
    }
  }

}