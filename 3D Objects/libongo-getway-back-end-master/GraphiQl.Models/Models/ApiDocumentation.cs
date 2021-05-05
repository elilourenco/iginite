using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libongo.Services.GeoLocalizacao;

namespace libongo.Models
{
  public partial class ApiDocumentation
  {
    [Key]
    public string Id { get; set; }

    public string url { get; set; }

    public string tipo { get; set; }

    public string obj { get; set; }

    public string methodo { get; set; }

    public string query { get; set; }

    public string mutation { get; set; }


    public object data { get; set; }

    public string RouteId { get; set; }

    public string MethodsId { get; set; }

    public string AspNetUsersId { get; set; }


    public List<Object> objgraphql { get; set; }

    public virtual Documentationheader Documentationheader {get; set;}

    public virtual RoutesMethods RoutesMethods {get; set;}

    public string EnsureSuccessStatusCode { get; set; }

  }
}