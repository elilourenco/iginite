using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class MicroServiceConfig
  {
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }

    public string UserName {get;set;}
    public string MicroServiceId { get; set; }
    [ForeignKey("MicroServiceId")]
    [InverseProperty("MicroService")]
    public virtual MicroServices MicroServices { get; set; } 
    public string  ApiResourcesId {get;set;}
    [ForeignKey("ApiResourcesId")]
    [InverseProperty("ApiResources")]
    public virtual ApiResources ApiResources { get; set; }
    public string  AmbientTypeId {get;set;} 
    [ForeignKey("AmbientTypeId")]
    [InverseProperty("AmbientTypes")]
    public virtual AmbientTypes AmbientTypes { get; set; }
     
  }
}
