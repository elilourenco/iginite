using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class RoutesCountriesType : ObjectGraphType<RoutesCountries> {
          public RoutesCountriesType () {
               Name = "RoutesCountries";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId == null?null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
               FieldAsync<ListGraphType<CountryType>> ("Country", resolve : async c => c.Source.CountryId == null?null : new manipulacao ().selectOne<Country> (new Country (), c.Source.CountryId.ToString ()));
               Field (x => x.CodRoutesCountries, nullable : true);
               Field (x => x.CreationDate, nullable : true);
               Field (x => x.UpdateDate, nullable : true);
               FieldAsync<ListGraphType<SelectedProvincesType>> ("SelectedProvinces", resolve : async c => c.Source.Id == null?null : new manipulacao ().selectOne<SelectedProvinces> (new SelectedProvinces (), c.Source.Id.ToString ()));
          }
     }
     public class RoutesCountriesInputType : InputObjectGraphType {
          public RoutesCountriesInputType () {
               Name = "RoutesCountriesInput";
               Field<StringGraphType> ("RouteId");
               Field<RoutesInputType> ("Routes");
               Field<StringGraphType> ("CountryId");
               Field<CountryInputType> ("Country");
               Field<StringGraphType> ("CodRoutesCountries");
               Field<ListGraphType<SelectedProvincesInputType>> ("SelectedProvinces");
               Field<DateTimeGraphType> ("CreationDate");
               Field<DateTimeGraphType> ("UpdateDate");
          }
     }

}