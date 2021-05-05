using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class IdentityResourceProperties
    {
        [Key]
        public string Id { get; set; }
        public string Key {get;set;} 
        public string Value {get;set;} 
        public string IdentityResourceId {get;set;} 
        [ForeignKey("IdentityResourceId")]
        [InverseProperty("IdentityResourceProperties")] 
        public virtual IdentityResources IdentityResources {get;set;} 
    }
    
}
