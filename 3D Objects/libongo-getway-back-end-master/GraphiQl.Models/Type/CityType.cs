using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class CityType : ObjectGraphType<City> {
    public CityType () {
      Name = "City";
      Field (x => x.Id, nullable : true);
      Field (x => x.CityCod, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<ProvinceType>> ("Province", resolve : async c => c.Source.CountyId == null?null : new manipulacao ().selectOne<Province> (new Province (), c.Source.CountyId.ToString ()));
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
    }
  }
  public class CityInputType : InputObjectGraphType {
    public CityInputType () {
      Name = "CityInput";
      Field<StringGraphType> ("CityCod");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("CountyId");
      Field<ProvinceInputType> ("Province");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }

}