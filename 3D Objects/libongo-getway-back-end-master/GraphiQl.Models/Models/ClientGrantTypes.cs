using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientGrantTypes
    {
        [Key]
        public string Id { get; set; }
        public string GrantType {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientGrantTypes")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
