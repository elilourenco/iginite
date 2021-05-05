using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiScopeProperties
    {
        [Key]
        public string Id { get; set; }
        public string Key {get;set;} 
        public string Value {get;set;} 
        public string ScopeId {get;set;} 
        [ForeignKey("ScopeId")]
        [InverseProperty("ApiScopeProperties")] 
        public virtual ApiScopes ApiScopes {get;set;} 
    }
    
}
