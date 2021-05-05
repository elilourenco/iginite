using Confluent.Kafka;
using ServiceStack.Redis;
using System;
using System.Linq;

namespace libongo.Services.Redis
{
  public class RedisClients
  {
    private string host = "localhost";
    private RedisClient _RedisClient;


    public bool CheckConnRedis(string HostName,string UserName,string Password,int porta)
    {
      try
      {
        _RedisClient = new RedisClient(HostName,porta);
        return true;
      }
      catch (ArgumentException)
      {
        return false;
      }
    }

    public void SendCashe<TModel>(TModel obj,string name)
    {
      using (_RedisClient)
      {
        var type = obj.GetType();
        /* 
        var primary = obj.GetType().GetProperties().FirstOrDefault(x => x.CustomAttributes.Any(x => x.AttributeType.Name.Equals("KeyAttribute")));
        foreach (var item in type.GetProperties())
        {
          if (item.Name == primary.ToString())
          {
            value = item.GetValue(item.Name).ToString();
          }
        }
        */
        _RedisClient.Set<TModel>(name, obj);

        var client = _RedisClient.Get<TModel>("consulta");
        //var ft = redisClient.GetAll<TModel>();
        //var dr = redisClient.GetAllKeys();
        //foreach (var uo in dr)
        //{
        //clintes.Add(redisClient.Get<cliente>(uo));
        //}
        //Console.WriteLine(client.nome, client.key, client.info);
      }

      
    }

    public TModel GetCashe<TModel>(string name)
    {
      TModel client;
      using (_RedisClient)
      {
      
        client = _RedisClient.Get<TModel>("consulta");
      }
      return client;
    }
  }
}