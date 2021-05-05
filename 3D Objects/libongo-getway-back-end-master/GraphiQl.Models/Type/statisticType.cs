using GraphQL.Types;
using libongo.Models;

namespace libongo.Type
{
  public class statisticsClientClientType : ObjectGraphType<statisticsClientClient>
  {
    public statisticsClientClientType()
    {
      Name = "statisticsbycategory";

      Field(x => x.TotalCustomer, nullable: true);
      Field(x => x.Totalactivecustomers, nullable: true);
      Field(x => x.Totalinactivecustomers, nullable: true);
      Field(x => x.month, nullable: true);
      Field(x => x.year, nullable: true);
      //statisticsClientClient
    }
  }

  public class statisticsClientClientInputType : InputObjectGraphType {
    public statisticsClientClientInputType () {
      Name = "statisticsClientClientInput";

      Field<StringGraphType> ("year");
    }
  }
}