using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class PersistedGrantsType : ObjectGraphType<PersistedGrants> {
    public PersistedGrantsType () {
      Name = "PersistedGrants";
      Field (x => x.Id, nullable : true);
      Field (x => x.Key, nullable : true);
      Field (x => x.Type, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.CreationTime, nullable : true);
      Field (x => x.Expiration, nullable : true);
      Field (x => x.ConsumedTime, nullable : true);
      Field (x => x.Data, nullable : true);
    }
  }
  public class PersistedGrantsInputType : InputObjectGraphType {
    public PersistedGrantsInputType () {
      Name = "PersistedGrantsInput";
      Field<StringGraphType> ("Key");
      Field<StringGraphType> ("Type");
      Field<StringGraphType> ("Description");
      Field<DateTimeGraphType> ("CreationTime");
      Field<DateTimeGraphType> ("Expiration");
      Field<DateTimeGraphType> ("ConsumedTime");
      Field<StringGraphType> ("Data");
    }
  }

}