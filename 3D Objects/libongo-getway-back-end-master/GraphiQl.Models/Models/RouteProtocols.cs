using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class RouteProtocols
    {
        [Key]
        public string Id { get; set; }
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("RouteProtocols")] 
        public virtual Routes Routes {get;set;} 
        public string ProtocolId {get;set;} 
        [ForeignKey("ProtocolId")]
        [InverseProperty("RouteProtocols")] 
        public virtual Protocols Protocols {get;set;} 
    }
    
}
