using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models {
    public partial class AlertsRoute {
        
      public string Alert { get; set; }
      public string AlertDescription { get; set; }

      public string AlertType { get; set; }

      public string AlertCondition { get; set; }

      public int MetricThreshold { get; set; }

      public string Route { get; set; }

      public string ApiResource { get; set; }

      public string OwnerName { get; set; }

      public string OwnerEmail { get; set; }

       
    }

}