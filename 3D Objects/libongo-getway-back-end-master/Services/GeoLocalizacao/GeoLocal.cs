using System;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace libongo.Services.GeoLocalizacao {

  public class GeoLocal {

    public  RootObject getAddress (string latitude, string longitute)

    {
      latitude = latitude.Replace (',', '.');
      longitute = longitute.Replace (',', '.');

      WebClient webClient = new WebClient ();

      webClient.Headers.Add ("user-agent", "Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

      webClient.Headers.Add ("Referer", "http://www.microsoft.com");

      var jsonData = webClient.DownloadData ("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + latitude + "&lon=" + longitute);

      DataContractJsonSerializer ser = new DataContractJsonSerializer (typeof (RootObject));

      RootObject rootObject = (RootObject) ser.ReadObject (new MemoryStream (jsonData));

      return rootObject;
    }
  }
}