using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class SchemaRoute
    {
        [Key]
        public string Id { get; set; }
        public string SchemaGraphQId {get;set;} 
        [ForeignKey("SchemaGraphQId")]
        [InverseProperty("SchemaRoute")] 
        public virtual SchemaGraphQ SchemaGraphQ {get;set;} 
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("SchemaRoute")] 
        public virtual Routes Routes {get;set;} 
        public string Objecto {get;set;} 

        public string ObjectoType {get;set;} 
    }
    
}
