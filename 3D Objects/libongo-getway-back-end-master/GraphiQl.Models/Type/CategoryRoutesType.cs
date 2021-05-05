using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class CategoryRoutesType : ObjectGraphType<CategoryRoutes>
  {
    public CategoryRoutesType()
    {
      Name = "CategoryRoutes";
      Field(x => x.Id, nullable: true);
      Field(x => x.Name, nullable: true);
      FieldAsync<ListGraphType<SubCategoryRoutesType>> ("SubCategoryRoutes", resolve : async c => c.Source.Id==null?null:  new manipulacao ().selectOne<SubCategoryRoutes> (new SubCategoryRoutes(), c.Source.Id.ToString ()));
    }
  }
  public class CategoryRoutesInputType : InputObjectGraphType
  {
    public CategoryRoutesInputType()
    {
      Name = "CategoryRoutesInput";
      Field<StringGraphType>("Name");
    }
  }
}
