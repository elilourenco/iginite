using System.Collections.Generic;
using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;
using libongo.Services.GeoLocalizacao;

namespace libongo.Type
{
  public class AddressType : ObjectGraphType<address>
  {
    public AddressType()
    {
      Name = "address";
      Field(x => x.city, nullable: true);
      Field(x => x.city_district, nullable: true);
      Field(x => x.country, nullable: true);
      Field(x => x.country_code, nullable: true);
      Field(x => x.county, nullable: true);
      Field(x => x.house_number, nullable: true);
      Field(x => x.neighbourhood, nullable: true);
      Field(x => x.place, nullable: true);
      Field(x => x.postcode, nullable: true);
      Field(x => x.railway, nullable: true);
      Field(x => x.road, nullable: true);
      Field(x => x.state, nullable: true);
      Field(x => x.state_district, nullable: true);
      Field(x => x.suburb, nullable: true);
    }
  }
}