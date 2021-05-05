using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class SchemaGraphQType : ObjectGraphType<SchemaGraphQ> {
    public SchemaGraphQType () {
      Name = "SchemaGraphQ";
      Field (x => x.Name, nullable : true);
      Field (x => x.Id, nullable : true);
    }
  }
  public class SchemaGraphQInputType : InputObjectGraphType {
    public SchemaGraphQInputType () {
      Name = "SchemaGraphQInput";
      Field<StringGraphType> ("Name");
    }
  }

}