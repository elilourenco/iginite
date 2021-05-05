using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class RoutesMethods
    {
        [Key]
        public string Id { get; set; }
        public string MethodId {get;set;} 
        [ForeignKey("MethodId")]
        [InverseProperty("RoutesMethods")] 
        public virtual Methods Methods {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("RoutesMethods")] 
        public virtual Routes Routes {get;set;} 
    }
    
}
