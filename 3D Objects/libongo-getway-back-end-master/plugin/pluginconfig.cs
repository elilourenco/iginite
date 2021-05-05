using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace libongo.plugin {
  public class pluginconfig {

    public async Task<bool> Checkconnection<T> (int Port, string Name, string password, List<T> _obj, string tb) {

      //string strJson = JsonConvert.SerializeObject (dados, Formatting.Indented);

      string payload = "";
      string paload_init = "{\n\t\n\t";
      int conta = 0;

      var userName = "elastic";
      var passwd = "1b0WNf39ZLnh57F399S5RGDS";

      foreach (var prop in _obj) {
        foreach (var item in prop.GetType ().GetProperties ()) {
          if (item.PropertyType.Name != "ICollection`1" && item.PropertyType.Name == "String") {
            conta++;
            if (conta <= 11 && item.GetValue (prop) != null) {
              payload += $"\n\t\"{item.Name}\":\"{item.GetValue(prop)}\",";
            }
          }
        }
      }

      paload_init += payload + "}";

      string h = paload_init.Replace (",}", "\n\t\n}");

      

      bool check = false;

      try {
        if (Name.ToUpper () == "KIBANA") 
        {

          
          var url = $"https://snir.elasticsearch.139.59.52.164.nip.io/";

          using var client = new HttpClient();
          var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
          Convert.ToBase64String(authToken));
          client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          var result = await client.GetAsync(url);
          
          if (result.IsSuccessStatusCode) 
          {
            check = true;
            post (h, tb, Port);
          }
          
        }
      } catch (System.Exception) {
        check = false;
      }

      string post (string obj, string tb, int port) {

        string response = "";

        try {
         
          string routa = tb.ToLower ();

          Uri uri = new Uri($"https://snir.elasticsearch.139.59.52.164.nip.io/{routa}/{tb}");

          var credentialCache = new CredentialCache();
            credentialCache.Add(
            new Uri(uri.GetLeftPart(UriPartial.Authority)), 
            "Basic", 
            new NetworkCredential(userName, passwd) 
          );
          
          using (WebClient client = new WebClient ()) {
            client.UseDefaultCredentials = true;
            client.Credentials = credentialCache;
            
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            response = client.UploadString (uri, obj);
            check = true;
          }
          
        } catch (Exception ex) {

          response = "";
          check = false;
        }
        return response;
      }
      return check;
    }
  }
}