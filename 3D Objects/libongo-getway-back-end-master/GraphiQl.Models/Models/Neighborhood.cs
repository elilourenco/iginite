using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Neighborhood
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string DistrictId {get;set;} 
        [ForeignKey("DistrictId")]
        [InverseProperty("Neighborhood")] 
        public virtual District District {get;set;} 
         public string NeighborhoodCod {get;set;} 
         public DateTime CreationDate {get;set;} 
         public DateTime UpdateDate {get;set;} 
         public string StatussId {get;set;} 
         [ForeignKey("StatussId")]
         [InverseProperty("Neighborhood")] 
         public virtual Statuss Statuss {get;set;} 
    }
    
}
