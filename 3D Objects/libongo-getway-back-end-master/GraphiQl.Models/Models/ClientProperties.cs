using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientProperties
    {
        [Key]
        public string Id { get; set; }
        public string Key {get;set;} 
        public string Value {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientProperties")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
