using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Error
    {
        [Key]
        public string Id {get;set;} 
        
        public string CodError {get;set;} public string Message {get;set;} public string Description {get;set;} public string DatasheetId {get;set;} [ForeignKey("DatasheetId")][InverseProperty("Error")] public virtual Datasheet Datasheet {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
