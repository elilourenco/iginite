using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class CategoryRoutes
    {
        [Key]
        public string Id { get; set; }
        public string Name {get;set;} 

        public virtual SubCategoryRoutes SubCategoryRoutes { get; set; } 
    }
}
