using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
  public partial class FieldApi
  {
    [Key]
    public string Id { get; set; }
    public string url { get; set; }
    public string tipo { get; set; }
    public string obj { get; set; }
    public string methodo { get; set; }
    public string RouteId { get; set; }
    public object returnobj { get; set; }
  }
}