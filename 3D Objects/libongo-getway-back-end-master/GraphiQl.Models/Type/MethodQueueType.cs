using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class MethodQueueType : ObjectGraphType<MethodQueue> {
          public MethodQueueType () {
               Name = "MethodQueue";
               Field(x => x.Id, nullable: true);
               FieldAsync<ListGraphType<MethodsType>> ("Methods", resolve : async c =>c.Source.IdMethods==null?null: new manipulacao ().selectOne<Methods> (new Methods (), c.Source.IdMethods.ToString ()));
               FieldAsync<ListGraphType<QueueType>> ("Queue", resolve : async c =>c.Source.IdQueue==null?null: new manipulacao ().selectOne<Queue> (new Queue (), c.Source.IdQueue.ToString ()));
          }
     }
     public class MethodQueueInputType : InputObjectGraphType {
          public MethodQueueInputType () {
               Name = "MethodQueueInput";
               Field<StringGraphType> ("IdMethods");
               Field<MethodsInputType> ("Methods");
               Field<StringGraphType> ("IdQueue");
               Field<QueueInputType> ("Queue");
          }
     }

}