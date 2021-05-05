using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class PluginType : ObjectGraphType<Plugin> {
    public PluginType () {
      Name = "Plugin";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      FieldAsync<ListGraphType<PluginConfigType>> ("PluginConfig", resolve : async c => c.Source.Id == null?null : new manipulacao ().selectOne<PluginConfig> (new PluginConfig (), c.Source.Id.ToString ()));
    }
  }
  public class PluginInputType : InputObjectGraphType {
    public PluginInputType () {
      Name = "PluginInput";
      Field<StringGraphType> ("Name");
      Field<PluginConfigInputType> ("PluginConfig");

    }
  }

}