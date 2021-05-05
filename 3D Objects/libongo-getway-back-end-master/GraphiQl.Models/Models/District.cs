using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class District
    {
        [Key]
        public string Id {get;set;} 
        
        public string Name {get;set;} 
        public string CountyId {get;set;} 
        [ForeignKey("CountyId")]
        [InverseProperty("District")] 
        public virtual County County {get;set;} 
        
        public string DistrictCod {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
        public string StatussId {get;set;} 
        [ForeignKey("StatussId")]
        [InverseProperty("District")] 
        public virtual Statuss Statuss {get;set;} 
    }
    
}
