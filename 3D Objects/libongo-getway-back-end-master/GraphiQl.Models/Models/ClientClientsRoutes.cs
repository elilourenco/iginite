using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ClientClientsRoutes
    {
        [Key]
        public string Id { get; set; }
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("ClientClientsRoutes")] 
        public virtual Routes Routes {get;set;} 
        public string ClientClientsId {get;set;} 
        [ForeignKey("ClientClientsId")]
        [InverseProperty("ClientClients")] 
        public virtual ClientClients ClientClients {get;set;} 
    }
    
}
