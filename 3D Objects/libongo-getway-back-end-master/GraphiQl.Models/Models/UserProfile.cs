using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class UserProfile
  {
    [Key]
    public string Id {get;set;}
    public string AspNetUserId { get; set; }
    [ForeignKey("AspNetUserId")]
    [InverseProperty("UserProfile")]
    public virtual AspNetUsers AspNetUsers { get; set; }
    public string AspNetRolesId { get; set; }
    [ForeignKey("AspNetRolesId")]
    [InverseProperty("AspNetRoles")]
    public virtual AspNetRoles AspNetRoles { get; set; }
  }

}
