using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientCorsOrigins
    {
        [Key]
        public string Id { get; set; }
        public string Origin {get;set;} 
        public int ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientCorsOrigins")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
