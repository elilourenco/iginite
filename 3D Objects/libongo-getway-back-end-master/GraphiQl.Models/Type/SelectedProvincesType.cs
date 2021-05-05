using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class SelectedProvincesType : ObjectGraphType<SelectedProvinces> {
          public SelectedProvincesType () {
               Name = "SelectedProvinces";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<ProvinceType>> ("Province", resolve : async c => c.Source.ProvinceId == null?null : new manipulacao ().selectOne<Province> (new Province (), c.Source.ProvinceId.ToString ()));
               FieldAsync<ListGraphType<RoutesCountriesType>> ("RoutesCountries", resolve : async c => c.Source.RoutesCountriesId == null?null : new manipulacao ().selectOne<RoutesCountries> (new RoutesCountries (), c.Source.RoutesCountriesId.ToString ()));
               Field (x => x.CodSelectedProvinces, nullable : true);
               Field (x => x.CreationDate, nullable : true);
               Field (x => x.UpdateDate, nullable : true);
          }
     }
     public class SelectedProvincesInputType : InputObjectGraphType {
          public SelectedProvincesInputType () {
               Name = "SelectedProvincesInput";
               Field<StringGraphType> ("ProvinceId");
               Field<ProvinceInputType> ("Province");
               Field<StringGraphType> ("RoutesCountriesId");
               Field<RoutesCountriesInputType> ("RoutesCountries");
               Field<StringGraphType> ("CodSelectedProvinces");
               Field<DateTimeGraphType> ("CreationDate");
               Field<DateTimeGraphType> ("UpdateDate");
          }
     }

}