using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libongo.Services.GeoLocalizacao;

namespace libongo.Models
{
  public partial class ApiGetWey
  {
    [Key]
    public string Id { get; set; }
    public string url { get; set; }
    public string tipo { get; set; }
    public string obj { get; set; }
    public string methodo { get; set; }
    public string query { get; set; }
    public string mutation { get; set; }
    public object returnobj { get; set; }
    public string ServiceName { get; set; }
    public string RouteName { get; set; }
    public string Canal { get; set; }
    public string ClientClientsId { get; set; }
    public string Routas { get; set; }
    public virtual Restrictions Restrictions{get;set;}
    public List<Object> objgraphql { get; set; }
    public virtual RootObject Localizacao{get;set;}
  }
}