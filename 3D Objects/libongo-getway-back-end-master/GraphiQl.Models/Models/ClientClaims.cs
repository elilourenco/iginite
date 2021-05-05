using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientClaims
    {
        [Key]
        public string Id { get; set; }
        public string Type {get;set;} 
        public string Value {get;set;} 
        public string ClientId {get;set;}
        [ForeignKey("ClientId")]
        [InverseProperty("ClientClaims")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
