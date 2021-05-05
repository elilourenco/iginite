using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiResourceScopes
    {
        [Key]
        public string Id { get; set; }
        public string Scope {get;set;} 
        public string ApiResourceId {get;set;} 
        [ForeignKey("ApiResourceId")]
        [InverseProperty("ApiResourceScopes")] 
        public virtual ApiResources ApiResources {get;set;} 
    }
    
}
