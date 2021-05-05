using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class HeadersRoutes
    {
        [Key]
        public string Id { get; set; }
        public string HeaderId {get;set;} 
        [ForeignKey("HeaderId")]
        [InverseProperty("HeadersRoutes")] 
        public virtual Headers Headers {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("HeadersRoutes")] 
        public virtual Routes Routes {get;set;} 
    }
    
}
