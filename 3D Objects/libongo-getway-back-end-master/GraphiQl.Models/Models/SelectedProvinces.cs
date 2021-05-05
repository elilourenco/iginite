using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SelectedProvinces
    {
        [Key]
        public string Id {get;set;} 
        
        public string ProvinceId {get;set;} 
        [ForeignKey("ProvinceId")]
        [InverseProperty("SelectedProvinces")] 
        public virtual Province Province {get;set;} 
        public string RoutesCountriesId {get;set;} 
        [ForeignKey("RoutesCountriesId")]
        [InverseProperty("SelectedProvinces")] 
        public virtual RoutesCountries RoutesCountries {get;set;} 
        public string CodSelectedProvinces {get;set;}  
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
    }
    
}
