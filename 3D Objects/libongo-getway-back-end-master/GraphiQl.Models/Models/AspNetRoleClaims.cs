using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class AspNetRoleClaims
    {
        [Key]
        public string Id { get; set; }
        public string RoleId {get;set;} 
        [ForeignKey("RoleId")]
        [InverseProperty("AspNetRoleClaims")] 
        public virtual AspNetRoles AspNetRoles {get;set;}
        public string ClaimType {get;set;}
        public string ClaimValue {get;set;} 
    }
    
}
