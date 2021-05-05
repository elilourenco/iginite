using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientSecrets
    {
        [Key]
        public string Id { get; set; }
        public string Description {get;set;} 
        public string Value {get;set;} 
        public DateTime Expiration {get;set;} 
        public string Type {get;set;} 
        public DateTime Created {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientSecrets")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
