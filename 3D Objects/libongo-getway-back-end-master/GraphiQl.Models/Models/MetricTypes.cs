using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MetricTypes
    {
        [Key]
        public string Id {get;set;} 
        
        public string Type {get;set;} 
        public string CodMetricType {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 
    }
    
}
