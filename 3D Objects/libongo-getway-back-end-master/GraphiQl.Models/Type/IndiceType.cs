using GraphQL.Types;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Type
{
  public class IndiceType : ObjectGraphType<Indice>
  {
    public IndiceType()
    {
         Name = "Indice";
         Field(x => x.Id, nullable: true);
         FieldAsync<ListGraphType<ItemType>>("Item", resolve : async c =>c.Source.ItemId == null?null :  new manipulacao().selectOne<Item> (new Item(),c.Source.ItemId.ToString())); Field(x => x.Description, nullable: true); Field(x => x.Image, nullable: true); Field(x => x.DescriptionImage, nullable: true);FieldAsync<ListGraphType<DatasheetType>>("Datasheet", resolve : async c =>c.Source.DatasheetId == null?null :  new manipulacao().selectOne<Datasheet> (new Datasheet(),c.Source.DatasheetId.ToString()));FieldAsync<ListGraphType<UrlType>>("Url", resolve : async c =>c.Source.UrlId == null?null :  new manipulacao().selectOne<Url> (new Url(),c.Source.UrlId.ToString())); Field(x => x.CreationDate, nullable: true);
    }
  }
   public class IndiceInputType: InputObjectGraphType
    {
        public IndiceInputType()
        {
             Name = "IndiceInput";
             Field<StringGraphType>("ItemId");Field<ItemInputType>("Item");Field<StringGraphType>("Description");Field<StringGraphType>("Image");Field<StringGraphType>("DescriptionImage");Field<StringGraphType>("DatasheetId");Field<DatasheetInputType>("Datasheet");Field<StringGraphType>("UrlId");Field<UrlInputType>("Url");Field<DateTimeGraphType>("CreationDate");
        }
    }

}
