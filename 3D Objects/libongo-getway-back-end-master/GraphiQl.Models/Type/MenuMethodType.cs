using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
     public class MenuMethodType : ObjectGraphType<MenuMethod> {
          public MenuMethodType () {
               Name = "MenuMethod";
               Field (x => x.Id, nullable : true);
               FieldAsync<ListGraphType<MenuType>> ("Menu", resolve : async c => c.Source.MenuId == null?null : new manipulacao ().selectOne<Menu> (new Menu (), c.Source.MenuId.ToString ()));
               FieldAsync<ListGraphType<MethodsType>> ("Methods", resolve : async c => c.Source.MethodId == null?null : new manipulacao ().selectOne<Methods> (new Methods (), c.Source.MethodId.ToString ()));
          }
     }
     public class MenuMethodInputType : InputObjectGraphType {
          public MenuMethodInputType () {
               Name = "MenuMethodInput";
               Field<StringGraphType> ("MenuId");
               Field<MenuInputType> ("Menu");
               Field<StringGraphType> ("MethodId");
               Field<MethodsInputType> ("Methods");
          }
     }

}