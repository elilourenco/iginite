using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class TypeAlertType : ObjectGraphType<TypeAlert>
  {
    public TypeAlertType()
    {
         Name = "TypeAlert";
         Field(x => x.Id, nullable: true);
          Field(x => x.Type, nullable: true);
    }
  }
   public class TypeAlertInputType: InputObjectGraphType
    {
        public TypeAlertInputType()
        {
             Name = "TypeAlertInput";
             Field<StringGraphType>("Type");
        }
    }

}
