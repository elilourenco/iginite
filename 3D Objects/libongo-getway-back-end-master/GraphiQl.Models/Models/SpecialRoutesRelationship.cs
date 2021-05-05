using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SpecialRoutesRelationship
    {
        [Key]
        public string Id {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("SpecialRoutesRelationship")] 
        public virtual Routes Routes {get;set;} 
        public string SpecialRouteId {get;set;} 
        [ForeignKey("SpecialRouteId")]
        [InverseProperty("SpecialRoutesRelationship")] 
        public virtual SpecialRoutes SpecialRoutes {get;set;} 
        
    }
    
}
