using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientPostLogoutRedirectUris
    {
        [Key]
        public string Id { get; set; }
        public string PostLogoutRedirectUri {get;set;}
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("ClientPostLogoutRedirectUris")] 
        public virtual Clients Clients {get;set;} 
    }
    
}
