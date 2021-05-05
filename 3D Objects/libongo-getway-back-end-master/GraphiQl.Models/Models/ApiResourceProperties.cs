using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiResourceProperties
    {
        [Key]
        public string Id { get; set; }
        public string Keys {get;set;} 
        public string Value {get;set;} 
        public string ApiResourceId {get;set;} 
        [ForeignKey("ApiResourceId")]
        [InverseProperty("ApiResourceProperties")] 
        public virtual ApiResources ApiResources {get;set;} 
    }
    
}
