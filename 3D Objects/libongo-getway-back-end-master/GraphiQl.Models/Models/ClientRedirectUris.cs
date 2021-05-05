using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientRedirectUris
    {
        [Key]
        public string Id { get; set; }
        public string RedirectUri {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientRedirectUris")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
