using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class PluginConfig
  {
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }
    public string Ip { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }

     public string PluginId { get;set;} 
     [ForeignKey("PluginId")]
     [InverseProperty("Plugin")] 
     public virtual Plugin Plugin { get;set;} 
  }

}