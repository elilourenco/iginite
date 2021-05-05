using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Country
    {
        [Key]
        public string Id {get;set;} 
        
        public string CountryCod {get;set;} 
        public string Name {get;set;} 
        public string RegionId {get;set;} 
        [ForeignKey("RegionId")]
        [InverseProperty("Country")] 
        public virtual Region Region {get;set;} 
        
        public string ContinentId {get;set;} 
        [ForeignKey("ContinentId")]
        [InverseProperty("Country")] 
        public virtual Continent Continent {get;set;} 
        
        public virtual Statuss Statuss {get;set;} 
        public string CodeISO {get;set;} 
        public string ImagePath {get;set;} 
    }
    
}
