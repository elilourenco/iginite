using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientClients
    {
        [Key]
        public string Id { get; set; }

        public bool IsActive {get;set;}

        //public string CreationDate {get;set;}

        public int Year {get;set;}

        public int month {get;set;}

        public string PersonId {get;set;} 
        [ForeignKey("PersonId")]
        [InverseProperty("Persons")] 
        public virtual Persons Persons {get;set;} 
        public string ClientId {get;set;} 
        [ForeignKey("ClientId")]
        [InverseProperty("Members")] 
        public virtual Clients Clients {get;set;} 

         public virtual statisticsClientClient statisticsClientClient {get;set;}
    }
    
}
