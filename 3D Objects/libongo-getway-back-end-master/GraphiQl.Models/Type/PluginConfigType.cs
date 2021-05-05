using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class PluginConfigType : ObjectGraphType<PluginConfig> {
    public PluginConfigType () {
      Name = "PluginConfig";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.Ip, nullable : true);
      Field (x => x.Port, nullable : true);
      Field (x => x.Password, nullable: true);
      Field (x => x.PluginId, nullable: true);
      FieldAsync<ListGraphType<PluginType>>("Plugin", resolve: async c =>c.Source.PluginId==null?null:  new manipulacao().selectOne<Plugin>(new Plugin(), c.Source.PluginId.ToString()));
      
    }
  }
  public class PluginConfigInputType : InputObjectGraphType {
    public PluginConfigInputType () {
      Name = "PluginConfigInput";
      Field<StringGraphType> ("PluginId");
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("Ip");
      Field<IntGraphType> ("Port");
      Field<StringGraphType> ("Password");
    }
  }

}