using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class SpecialRoutesRelationshipType : ObjectGraphType<SpecialRoutesRelationship> {
          public SpecialRoutesRelationshipType () {
               Name = "SpecialRoutesRelationship";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId == null?null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
               FieldAsync<ListGraphType<SpecialRoutesType>> ("SpecialRoutes", resolve : async c => c.Source.SpecialRouteId == null?null : new manipulacao ().selectOne<SpecialRoutes> (new SpecialRoutes (), c.Source.SpecialRouteId.ToString ()));
          }
     }
     public class SpecialRoutesRelationshipInputType : InputObjectGraphType {
          public SpecialRoutesRelationshipInputType () {
               Name = "SpecialRoutesRelationshipInput";
               Field<StringGraphType> ("RouteId");
               Field<RoutesInputType> ("Routes");
               Field<StringGraphType> ("SpecialRouteId");
               Field<SpecialRoutesInputType> ("SpecialRoutes");
          }
     }

}