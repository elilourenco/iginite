using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MethodQueue
    {
        [Key]
        public string Id { get; set; }

        public string IdMethods {get;set;} 
        [ForeignKey("IdMethods")]
        [InverseProperty("MethodQueue")] 
        public virtual Methods Methods {get;set;} 
        public string IdQueue {get;set;} 
        [ForeignKey("IdQueue")]
        [InverseProperty("MethodQueue")] 
        public virtual Queue Queue {get;set;} 
    }
    
}
