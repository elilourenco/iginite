using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Threading.Tasks;

namespace libongo.Services.Kafka
{

  public class kafkaClient
  {
    private ProducerConfig _ProducerConfig;

    public bool CheckConnkafka(string ip,int port)
    {
      try
      {
        _ProducerConfig = new ProducerConfig
        {
          BootstrapServers = $"{ip}:{port}"

        };
        return true;
      }
      catch (ArgumentException)
      {
        return false;
      }
    }
    public async Task CrearTopicAsync(string bootstrapServers, string topicName)
    {
      //https://github.com/confluentinc/confluent-kafka-dotnet/blob/b7b04fed82762c67c2841d7481eae59dee3e4e20/examples/AdminClient/Program.cs
      using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = bootstrapServers }).Build())
      {
        try
        {
          await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                        new TopicSpecification { Name = topicName, ReplicationFactor = 1, NumPartitions = 1 } });
        }
        catch (CreateTopicsException e)
        {
          Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
        }
      }
    }
    public async void createTopic(string topic)
    {
      using var p = new ProducerBuilder<Null, string>(_ProducerConfig).Build();
      {
        try
        {
          var topico = await p.ProduceAsync(topic, new Message<Null, string> { Value = null });
        }
        catch (ProduceException<Null, string>)
        {
          return;
        }
      }
    }
  }
}