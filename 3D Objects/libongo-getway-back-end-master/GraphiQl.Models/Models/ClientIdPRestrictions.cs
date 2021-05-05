using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientIdPRestrictions
    {
        [Key]
        public string Id { get; set; }
        public string Provider {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientIdPRestrictions")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
