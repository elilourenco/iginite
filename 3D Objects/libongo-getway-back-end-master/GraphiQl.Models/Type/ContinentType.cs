using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class ContinentType : ObjectGraphType<Continent> {
    public ContinentType () {
      Name = "Continent";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.CodContinent, nullable : true);
      Field (x => x.CreationDate, nullable : true);
      Field (x => x.UpdateDate, nullable : true);
      FieldAsync<ListGraphType<StatussType>> ("Statuss", resolve : async c => c.Source.StatussId == null?null : new manipulacao ().selectOne<Statuss> (new Statuss (), c.Source.StatussId.ToString ()));
      FieldAsync<ListGraphType<CountryType>> ("Country", resolve : async c => c.Source.Id == null?null : new manipulacao ().selectOne<Country> (new Country (), c.Source.Id.ToString ()));
    }
  }
  public class ContinentInputType : InputObjectGraphType {
    public ContinentInputType () {
      Name = "ContinentInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("CodContinent");
      Field<DateTimeGraphType> ("CreationDate");
      Field<DateTimeGraphType> ("UpdateDate");
      Field<StringGraphType> ("StatussId");
      Field<StatussInputType> ("Statuss");
    }
  }

}