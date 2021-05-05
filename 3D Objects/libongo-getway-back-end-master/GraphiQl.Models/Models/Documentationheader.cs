using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libongo.Services.GeoLocalizacao;

namespace libongo.Models
{
  public partial class Documentationheader
  {
    public string description { get; set; } 
    public string version { get; set; } 
    public string termsOfService { get; set; }
    public string title { get; set; }
    public virtual  contacts contacts {get; set;}
  }

  public partial class contacts
  {
    public string email { get; set; } 

    public string contact { get; set; } 
     
  }
}