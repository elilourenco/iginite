

namespace libongo.Services.Kafka
{
  public interface IkafkaClient
  {
    System.Threading.Tasks.Task CreateConnectionAsync(string topic);
  }
}