using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Queue
    {
        [Key]
        public string Id { get; set; }

        public string Name {get;set;} 
        public string IdRoute {get;set;} 
        [ForeignKey("IdRoute")]
        [InverseProperty("Queue")] 
        public virtual Routes Routes {get;set;} 
    }
    
}
