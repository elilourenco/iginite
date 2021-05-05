using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class RoutesCanal
  {
    [Key]
    public string Id { get; set; }
    public string RouteId { get; set; }
    [ForeignKey("RouteId")]
    [InverseProperty("RoutesCanal")]
    public virtual Routes Routes { get; set; }
    public string CanalId { get; set; }
    [ForeignKey("CanalId")]
    [InverseProperty("RoutesCanal")] 
    public virtual Canal Canal { get; set; }

    public string TypeReturnId { get; set; }
    [ForeignKey("TypeReturnId")]
    [InverseProperty("TypeReturn")] 
    public virtual TypeReturns TypeReturns { get; set; }
  }

}
