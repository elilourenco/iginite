using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Fields
    {
        [Key]
        public string Id {get;set;}
        public string Name {get;set;} 
        public string RoutesCanalId {get;set;}
        [ForeignKey("RoutesCanalId")]
        [InverseProperty("RoutesCanal")] 
        public virtual RoutesCanal RoutesCanal {get;set;} 
        public virtual ICollection<Restrictions> Restrictions {get;set;} 

    }
}