using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class PerfilClient
    {
        [Key]
        public string Id {get;set;} 
        
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("PerfilClient")] 
        public virtual Clients Clients {get;set;} 
        public string PerfilMembersId {get;set;} 
        [ForeignKey("PerfilMembersId")]
        [InverseProperty("PerfilClient")] 
        public virtual PerfilMembers PerfilMembers {get;set;} 

    }
}
