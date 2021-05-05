using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Province
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string RegionId {get;set;} 
        [ForeignKey("RegionId")]
        [InverseProperty("Province")] 
        public virtual Region Region {get;set;} 
        
        public string CountryId {get;set;} 
        [ForeignKey("CountryId")]
        [InverseProperty("Province")] 
        public virtual Country Country {get;set;} 
         public string ProvinceCod {get;set;} 
         public DateTime CreationDate {get;set;} 
         public DateTime UpdateDate {get;set;} 
         public string StatussId {get;set;} 
         [ForeignKey("StatussId")]
         [InverseProperty("Province")] 
         public virtual Statuss Statuss {get;set;} 
         
    }
    
}
