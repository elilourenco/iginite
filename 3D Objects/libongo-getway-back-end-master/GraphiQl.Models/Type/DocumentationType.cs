using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class DocumentationType : ObjectGraphType<Documentation> {
          public DocumentationType () {
               Name = "Documentation";
               //Field (x => x.Id, nullable : true);
               Field (x => x.PathsId, nullable : true);
               FieldAsync<ListGraphType<RoutesType>> ("Routes", resolve : async c => c.Source.RouteId == null?null : new manipulacao ().selectOne<Routes> (new Routes (), c.Source.RouteId.ToString ()));
               FieldAsync<ListGraphType<MethodsType>> ("Methods", resolve : async c => c.Source.MethodId == null?null : new manipulacao ().selectOne<Methods> (new Methods (), c.Source.MethodId.ToString ()));
               FieldAsync<ListGraphType<PathsType>> ("Paths", resolve : async c => c.Source.PathsId == null?null : new manipulacao ().selectOne<Paths> (new Paths (), c.Source.PathsId.ToString ()));
               Field (x => x.BaseUrl, nullable : true);
               Field (x => x.Obj, nullable : true);
          }
     }
     public class DocumentationInputType : InputObjectGraphType {
          public DocumentationInputType () {
               Name = "DocumentationInput";
               Field<StringGraphType> ("RouteId");
               Field<RoutesInputType> ("Routes");
               Field<StringGraphType> ("MethodId");
               Field<MethodsInputType> ("Methods");
               Field<StringGraphType> ("PathsId");
               Field<HostsInputType> ("Paths");
               Field<StringGraphType> ("BaseUrl");
               Field<StringGraphType> ("Obj");
          }
     }

}