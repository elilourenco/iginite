using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class RoutesCountries
    {
        [Key]
        public string Id {get;set;} 
        
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("RoutesCountries")] 
        public virtual Routes Routes {get;set;} 
        public string CountryId {get;set;} 
        [ForeignKey("CountryId")]
        [InverseProperty("RoutesCountries")] 
        public virtual Country Country {get;set;} 
         public string CodRoutesCountries {get;set;} 
         public string StatussId {get;set;} 
         [ForeignKey("StatussId")]
         [InverseProperty("RoutesCountries")] 
         public virtual Statuss Statuss {get;set;} 
         public DateTime CreationDate {get;set;} 
         public DateTime UpdateDate {get;set;} 

        public virtual ICollection<SelectedProvinces> SelectedProvinces {get;set;} 
    }
    
}
