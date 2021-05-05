using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class IdentityResourceClaims
    {
        [Key]
        public string Id { get; set; }
        public string Type {get;set;} 
        public string IdentityResourceId {get;set;} 
        [ForeignKey("IdentityResourceId")]
        [InverseProperty("IdentityResourceClaims")] 
        public virtual IdentityResources IdentityResources {get;set;} 
    }
    
}
