using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiScopeClaims
    {
        [Key]
        public string Id { get; set; }
        public string Type {get;set;} 
        public string ScopeId {get;set;} 
        [ForeignKey("ScopeId")]
        [InverseProperty("ApiScopeClaims")] 
        public virtual ApiScopes ApiScopes {get;set;} 
    }
    
}
