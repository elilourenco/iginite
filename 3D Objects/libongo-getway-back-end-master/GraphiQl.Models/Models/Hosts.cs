using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Hosts
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("Hosts")] 
        public virtual Routes Routes {get;set;} 
    }
    
}
