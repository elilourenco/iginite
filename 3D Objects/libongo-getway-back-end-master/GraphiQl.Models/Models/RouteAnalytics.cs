using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class RouteAnalytics
    {
        public RouteAnalytics()
        {
            statisticsClientClient= new List<statisticsClientClient>();
        }
        [Key]
        public string Id {get;set;} 
        
        public string RouteId {get;set;} 
        [ForeignKey("RouteId")]
        [InverseProperty("RouteAnalytics")] 
        public virtual Routes Routes {get;set;} 

        public string CanalId {get;set;} 
        [ForeignKey("CanalId")]
        [InverseProperty("Canal")] 

        public virtual Canal Canal {get;set;} 

        public string MethodId {get;set;} 
        [ForeignKey("MethodId")]
        [InverseProperty("Methods")] 
        public virtual Methods Methods {get;set;} 

        public int Error {get;set;} 
        public double Latency {get;set;} 
        public string Date {get;set;} 
        public string Hour {get;set;} 
        public DateTime CreationDate {get;set;} 
        public DateTime UpdateDate {get;set;} 

        public int APICalls {get;set;} 


        public virtual List<statisticsClientClient> statisticsClientClient {get;set;}

        public virtual ClientClients ClientClients {get;set;}

        public virtual int RequisitionMethods {get;set;} 
        public virtual int channelRequisition {get;set;} 
        public virtual int RequestsbyChannelandmethods {get;set;} 
    }

  

    public partial class statisticsClientClient
    {
        public int month {get;set;}
        public string year {get;set;}
        public string ClientClientsID {get;set;} 
        public int TotalCustomer {get;set;} 
        public int Totalactivecustomers {get;set;} 
        public int Totalinactivecustomers {get;set;} 

    }
}
