using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class PathsRoutes
    {
        [Key]
        public string Id { get; set; }
        public string PathId {get;set;} 
        [ForeignKey("PathId")]
        [InverseProperty("PathsRoutes")]
        public virtual Paths Paths {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("PathsRoutes")]
        public virtual Routes Routes {get;set;} 
    }
    
}
