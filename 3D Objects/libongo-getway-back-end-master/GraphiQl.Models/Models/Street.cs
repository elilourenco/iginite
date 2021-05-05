using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Street
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string StreetCod {get;set;} 
        public DateTime CreationDate {get;set;} 
         public DateTime UpdateDate {get;set;} 
         public string StatussId {get;set;} 
         [ForeignKey("StatussId")]
         [InverseProperty("Street")] 
         public virtual Statuss Statuss {get;set;}  
         public string NeighborhoodId {get;set;} 
         [ForeignKey("NeighborhoodId")]
         [InverseProperty("Street")] 
         public virtual Neighborhood Neighborhood {get;set;} 
         
    }
    
}
