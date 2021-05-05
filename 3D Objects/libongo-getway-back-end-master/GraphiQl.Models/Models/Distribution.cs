using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Distribution
    {
        [Key]
        public string Id {get;set;} 
        
        public string Title {get;set;} public string DatasheetId {get;set;} [ForeignKey("DatasheetId")][InverseProperty("Distribution")] public virtual Datasheet Datasheet {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
