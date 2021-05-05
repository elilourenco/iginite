using System;
using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class RouteAnalyticsType : ObjectGraphType<RouteAnalytics> {
          public RouteAnalyticsType () {
               Name = "RouteAnalytics";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId == null?null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
               Field (x => x.Error, nullable : true);
               Field (x => x.Latency, nullable : true);
               Field (x => x.Date, nullable : true);
               Field (x => x.Hour, nullable : true);
               Field (x => x.CreationDate, nullable : true);
               Field (x => x.UpdateDate, nullable : true);
               Field (x => x.RouteId, nullable : true);
               Field (x => x.APICalls, nullable : true);
               Field (x => x.channelRequisition, nullable : true);
               Field (x => x.RequestsbyChannelandmethods, nullable : true);
               Field (x => x.RequisitionMethods, nullable : true);
               //Field (x => x.m, nullable : true);
               FieldAsync<ListGraphType<CanalType>> ("Canal", resolve : async c => c.Source.CanalId == null?null : new manipulacao ().selectOne<Canal> (new Canal (), c.Source.CanalId.ToString ()));
               FieldAsync<ListGraphType<MethodsType>> ("Methods", resolve : async c => c.Source.MethodId == null?null : new manipulacao ().selectOne<Methods> (new Methods (), c.Source.MethodId.ToString ()));
               //Field(x => x.statisticsbycategory, nullable: true,typeof(statisticsbycategoryType));
               Field(x => x.statisticsClientClient, nullable: true,typeof(ListGraphType<statisticsClientClientType>));
                 
          }
     }
     public class RouteAnalyticsInputType : InputObjectGraphType {
          public RouteAnalyticsInputType () {


               Name = "RouteAnalyticsInput";
               
               Field<StringGraphType> ("RouteId");
               Field<StringGraphType> ("MethodId");
               Field<StringGraphType> ("Date");
               Field<StringGraphType> ("CanalId");
               Field<ClientClientsInputType>("ClientClients");
               /*
               Field<RoutesInputType> ("Routes");
               Field<FloatGraphType> ("Error");
               Field<FloatGraphType> ("Latency");
               Field<StringGraphType> ("Hour");
               Field<DateTimeGraphType> ("CreationDate");
               Field<DateTimeGraphType> ("UpdateDate");
               */
          }
     }

}