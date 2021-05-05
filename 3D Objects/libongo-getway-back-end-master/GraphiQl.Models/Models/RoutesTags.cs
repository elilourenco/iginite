using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class RoutesTags
    {
        [Key]
        public string Id { get; set; }
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("RoutesTags")] 
        public virtual Routes Routes {get;set;} 
        public string TagId {get;set;} 
        [ForeignKey("TagId")]
        [InverseProperty("RoutesTags")] 
        public virtual Tags Tags {get;set;} 
    }
    
}
