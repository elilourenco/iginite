using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type {
  public class SubCategoryRoutesType : ObjectGraphType<SubCategoryRoutes> {
    public SubCategoryRoutesType () {
      Name = "SubCategoryRoutes";
      Field (x => x.Id, nullable : true);
      Field (x => x.SubCategoryName, nullable : true);
      Field (x => x.CategoryRoutesId, nullable : true);
      FieldAsync<ListGraphType<CategoryRoutesType>> ("CategoryRoutes", resolve : async c => c.Source.CategoryRoutesId==null?null: new manipulacao ().selectOne<CategoryRoutes> (new CategoryRoutes (), c.Source.CategoryRoutesId.ToString ()));
    }
  }
  public class SubCategoryRoutesInputType : InputObjectGraphType {
    public SubCategoryRoutesInputType () {
      Name = "SubCategoryRoutesInput";
      Field<StringGraphType> ("SubCategoryName");
      Field<StringGraphType> ("CategoryRoutesId");
      Field<CategoryRoutesInputType>("CategoryRoutes");
    }
  }
}