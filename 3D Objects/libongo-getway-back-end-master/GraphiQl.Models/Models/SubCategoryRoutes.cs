using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SubCategoryRoutes
    {
        [Key] public string Id {get;set;} 
        public string SubCategoryName {get;set;} 
        public string CategoryRoutesId {get;set;} 
        [ForeignKey("CategoryRoutesId")]
        [InverseProperty("SubCategoryRoutes")] 
        public virtual CategoryRoutes CategoryRoutes {get;set;} 
    }
    
}
