
namespace libongo.Services.RabbitMQ
{
    public interface IRabbitMQClient
    {
        void Close();
        TModel Send<TModel>(string nomeExchange, string nomeQueue, string acao, TModel model)
           where TModel : class;
        string Receive(System.Type type,string name);

        bool CheckConn(string HostName,string UserName,string Password,int pot);
    }
}