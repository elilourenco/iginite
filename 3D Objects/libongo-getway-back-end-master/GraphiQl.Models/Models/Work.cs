using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Work
    {
        [Key]
        public string Id {get;set;} 
        
        public string Operacoes {get;set;} public string Funcionalidades {get;set;} public string Methods {get;set;} public string RestFullEnPoint {get;set;} public string DatasheetId {get;set;} [ForeignKey("DatasheetId")][InverseProperty("Work")] public virtual Datasheet Datasheet {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
