using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class MetricConditions
    {
        [Key]
        public string Id {get;set;} 
        
        public string Condition {get;set;} public string CodMetricCondition {get;set;} public DateTime CreationDate {get;set;} public DateTime UpdateDate {get;set;} 
    }
    
}
