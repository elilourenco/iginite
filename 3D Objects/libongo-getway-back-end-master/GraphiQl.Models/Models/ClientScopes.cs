using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientScopes
    {
        [Key]
        public string Id { get; set; }
        public string Scope {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientScopes")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
