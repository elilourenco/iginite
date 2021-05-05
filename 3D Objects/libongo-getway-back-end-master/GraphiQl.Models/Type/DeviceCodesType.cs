using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class DeviceCodesType : ObjectGraphType<DeviceCodes> {
    public DeviceCodesType () {
      Name = "DeviceCodes";
      Field (x => x.Id, nullable : true);
      Field (x => x.UserCode, nullable : true);
      Field (x => x.DeviceCode, nullable : true);
      Field (x => x.Description, nullable : true);
      Field (x => x.CreationTime, nullable : true);
      Field (x => x.Expiration, nullable : true);
      Field (x => x.Data, nullable : true);
    }
  }
  public class DeviceCodesInputType : InputObjectGraphType {
    public DeviceCodesInputType () {
      Name = "DeviceCodesInput";
      Field<StringGraphType> ("UserCode");
      Field<StringGraphType> ("DeviceCode");
      Field<StringGraphType> ("Description");
      Field<DateTimeGraphType> ("CreationTime");
      Field<DateTimeGraphType> ("Expiration");
      Field<StringGraphType> ("Data");
    }
  }

}