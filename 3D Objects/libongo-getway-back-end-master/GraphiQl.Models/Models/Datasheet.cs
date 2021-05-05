using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class Datasheet
  {
    [Key]
    public string Id { get; set; }

    public string Title { get; set; }
    public string Version { get; set; }
    public string Status { get; set; }
    public string Classification { get; set; }
    public string TypeDocument { get; set; }
    public DateTime CreationDate { get; set; }

    public string ApiResourceId {get;set;} 
    [ForeignKey("ApiResourceId")]
    [InverseProperty("ApiResources")] 
    public virtual ApiResources ApiResources {get;set;} 
        

  }

}