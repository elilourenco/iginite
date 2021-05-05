using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class ApiResourceClaims
    {
        [Key]
        public string Id { get; set; }
        public string Type {get;set;} 
        public string ApiResourceId {get;set;} 
        [ForeignKey("ApiResourceId")]
        [InverseProperty("ApiResourceClaims")] 
        public virtual ApiResources ApiResources {get;set;} 
    } 
}