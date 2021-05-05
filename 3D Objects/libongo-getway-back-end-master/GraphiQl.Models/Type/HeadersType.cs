using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class HeadersType : ObjectGraphType<Headers>
  {
    public HeadersType()
    {
         Name = "Headers";
            Field(x => x.Id, nullable: true);
            Field(x => x.Header, nullable: true);
    }
  }
   public class HeadersInputType: InputObjectGraphType
    {
        public HeadersInputType()
        {
             Name = "HeadersInput";
             Field<StringGraphType>("Header");
        }
    }

}
