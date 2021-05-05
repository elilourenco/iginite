using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class UrlType : ObjectGraphType<Url>
  {
    public UrlType()
    {
         Name = "Url";
         Field(x => x.Id, nullable: true);
          Field(x => x.Parameters, nullable: true); Field(x => x.IsObrigatory, nullable: true); Field(x => x.Type, nullable: true); Field(x => x.Description, nullable: true); Field(x => x.Example, nullable: true); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class UrlInputType: InputObjectGraphType
    {
        public UrlInputType()
        {
             Name = "UrlInput";
             Field<StringGraphType>("Parameters");Field<StringGraphType>("IsObrigatory");Field<StringGraphType>("Type");Field<StringGraphType>("Description");Field<StringGraphType>("Example");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
