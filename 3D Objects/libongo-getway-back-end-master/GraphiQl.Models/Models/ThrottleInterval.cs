using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class ThrottleInterval
  {
    [Key]
    public string Id { get; set; }

    public int IntervalValue { get; set; }
    public string ApiResourceId { get; set; }
    [ForeignKey("ApiResourceId")] 
    [InverseProperty("ThrottleInterval")] 
    public virtual ApiResources ApiResources { get; set; }
    public string CodThrottleInterval { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
  }

}
