using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiResourcesTags
    {
        [Key]
        public string Id { get; set; }
        public int ApiResourceId {get;set;} 
        [ForeignKey("ApiResourceId")]
        [InverseProperty("ApiResourcesTags")] 
        public virtual ApiResources ApiResources {get;set;} 
        public string TagId {get;set;} 
        [ForeignKey("TagId")]
        [InverseProperty("ApiResourcesTags")] 
        public virtual Tags Tags {get;set;} 
    }
    
}
