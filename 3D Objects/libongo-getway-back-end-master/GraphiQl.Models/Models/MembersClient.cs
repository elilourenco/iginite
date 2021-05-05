using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MembersClient
    {
        [Key]
        public string Id { get; set; }
        public string PersonsId {get;set;} 
        [ForeignKey("PersonsId")]
        [InverseProperty("Persons")] 
        public virtual Persons Persons {get;set;}
        
        public string ClientsId {get;set;} 
        [ForeignKey("ClientsId")]
        [InverseProperty("ClientsId")] 
        public virtual Clients Clients {get;set;} 

        public string PerfilMembersId {get;set;} 
        [ForeignKey("PerfilMembersId")]
        [InverseProperty("PerfilMembers")] 
        public virtual PerfilMembers PerfilMembers {get;set;}
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
    
}
