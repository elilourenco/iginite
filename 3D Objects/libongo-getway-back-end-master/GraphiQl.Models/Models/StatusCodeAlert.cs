using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class StatusCodeAlert
  {
    [Key]
    public string Id { get; set; }

    public string StatusCodeId { get; set; }
    [ForeignKey("StatusCodeId")] 
    [InverseProperty("StatusCodeAlert")] 
    public virtual StatusCode StatusCode { get; set; }
    public string AlertId { get; set; }
    [ForeignKey("AlertId")] 
    [InverseProperty("StatusCodeAlert")] 
    public virtual Alerts Alerts { get; set; }
    public string CodStatusCodeAlert { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
  }

}
