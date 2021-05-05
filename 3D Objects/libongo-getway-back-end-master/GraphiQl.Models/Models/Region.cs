using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Region
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string RegionCode {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
        public string StatussId {get;set;} 
        
        [ForeignKey("StatussId")]
        [InverseProperty("Region")] 
        public virtual Statuss Statuss {get;set;}  
    }
}
