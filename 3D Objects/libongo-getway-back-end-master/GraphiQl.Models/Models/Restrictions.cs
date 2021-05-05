using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class Restrictions
  {
    [Key]
    public string Id { get; set; }
    public string ClientClientsRoutesId { get; set; }
    [ForeignKey("ClientClientsRoutesId")]
    [InverseProperty("ClientClientsRoutes")]
    public virtual ClientClientsRoutes ClientClientsRoutes { get; set; }
    public string FieldsId { get; set; }
    [ForeignKey("FieldsId")]
    [InverseProperty("Fields")]
    public virtual Fields Fields { get; set; }
  }
}