using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models {
    public partial class Alerts {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int MetricThreshold { get; set; }
        public int MeasurementIntervalValue { get; set; }
        public string MeasurementIntervaUnitId { get; set; }
        [ForeignKey ("MeasurementIntervaUnitId")]
        [InverseProperty ("Alerts")] 
        public virtual IntervalUnits IntervalUnits { get; set; }
        public string RouteId { get; set; }
        [ForeignKey ("RouteId")]
        [InverseProperty ("RouteId")] 
        public virtual Routes Routes { get; set; }
        public string MetricTypeId { get; set; }
        [ForeignKey ("MetricTypeId")]
        [InverseProperty ("MetricType")] 
        public virtual MetricTypes MetricTypes { get; set; }

        public string MetricConditionId  { get; set; }
        [ForeignKey ("MetricConditionId ")]
        [InverseProperty ("MetricCondition")] 
        public virtual MetricConditions MetricConditions { get; set; }
        
        public bool  State  { get; set; }       
         public string CodAlert { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }

}