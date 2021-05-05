using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Indice
    {
        [Key]
        public string Id {get;set;} 
        
        public string ItemId {get;set;} [ForeignKey("ItemId")][InverseProperty("Indice")] public virtual Item Item {get;set;} public string Description {get;set;} public string Image {get;set;} public string DescriptionImage {get;set;} public string DatasheetId {get;set;} [ForeignKey("DatasheetId")][InverseProperty("Indice")] public virtual Datasheet Datasheet {get;set;} public string UrlId {get;set;} [ForeignKey("UrlId")][InverseProperty("Indice")] public virtual Url Url {get;set;} public DateTime CreationDate {get;set;} 
    }
    
}
