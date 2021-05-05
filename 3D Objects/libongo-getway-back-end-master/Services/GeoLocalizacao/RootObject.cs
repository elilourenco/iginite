using System;


namespace libongo.Services.GeoLocalizacao {

  public class RootObject

  {
    public string place_id { get; set; }

    public string licence { get; set; }

    public string osm_type { get; set; }

    public string osm_id { get; set; }

    public string lat { get; set; }

    public string lon { get; set; }

    public string display_name { get; set; }

    public address address { get; set; }
  }
}