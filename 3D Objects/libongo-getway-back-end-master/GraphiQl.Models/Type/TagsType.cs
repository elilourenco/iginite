using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class TagsType : ObjectGraphType<Tags>
  {
    public TagsType()
    {
         Name = "Tags";
            Field(x => x.Id, nullable: true);
            Field(x => x.Tag, nullable: true);
    }
  }
   public class TagsInputType: InputObjectGraphType
    {
        public TagsInputType()
        {
             Name = "TagsInput";
             Field<StringGraphType>("Tag");
        }
    }

}
