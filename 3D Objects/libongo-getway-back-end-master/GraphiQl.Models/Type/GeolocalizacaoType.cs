using System.Collections.Generic;
using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;
using libongo.Services.GeoLocalizacao;

namespace libongo.Type
{
  public class GeolocalizacaoType : ObjectGraphType<RootObject>
  {
    public GeolocalizacaoType()
    {
      Name = "Geolocalizacao";
      Field(x => x.address, nullable: true,typeof(AddressType));
      Field(x => x.display_name, nullable: true);
      Field(x => x.lat, nullable: true);
      Field(x => x.licence, nullable: true);
      Field(x => x.lon, nullable: true);
      Field(x => x.osm_id, nullable: true);
      Field(x => x.osm_type, nullable: true);
      Field(x => x.place_id, nullable: true);
      
    }
  }
  public class GeolocalizacaoInputType : InputObjectGraphType
  {
    public GeolocalizacaoInputType()
    {
      Name = "GeolocalizacaoInput";
      Field<StringGraphType>("lat");
      Field<StringGraphType>("lon");
    }
  }
}