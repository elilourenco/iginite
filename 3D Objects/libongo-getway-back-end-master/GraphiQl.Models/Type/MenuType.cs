using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class MenuType : ObjectGraphType<Menu> {
    public MenuType () {
      Name = "Menu";
      Field (x => x.Id, nullable : true);
      Field (x => x.Name, nullable : true);
      Field (x => x.Description, nullable : true);
      FieldAsync<ListGraphType<MenuMethodType>> ("MenuMethod", resolve : async c => c.Source.Id == null?null : new manipulacao ().selectOne<MenuMethod> (new MenuMethod (), c.Source.Id.ToString ()));
    }
  }
  public class MenuInputType : InputObjectGraphType {
    public MenuInputType () {
      Name = "MenuInput";
      Field<StringGraphType> ("Name");
      Field<StringGraphType> ("Description");
    }
  }

}