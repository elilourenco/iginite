using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class ItemType : ObjectGraphType<Item>
  {
    public ItemType()
    {
         Name = "Item";
         Field(x => x.Id, nullable: true);
          Field(x => x.ItemName, nullable: true); Field(x => x.Description, nullable: true); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class ItemInputType: InputObjectGraphType
    {
        public ItemInputType()
        {
             Name = "ItemInput";
             Field<StringGraphType>("ItemName");Field<StringGraphType>("Description");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
