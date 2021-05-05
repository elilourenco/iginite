using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using libongo.Helpers;
using libongo.InMemory;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace libongo.Services.RabbitMQ {
  public class RabbitMQClient : IRabbitMQClient {
    public int n = 1;
    protected ILogger<RabbitMQClient> Logger { get; }
    private ConnectionFactory _factory;
    public int t = 0;
    public string message;
    private IConnection _connection;
    protected IRepository Repo { get; }
    protected ContextServiceLocator contextServiceLocator { get; }
    private IModel _model;

    public RabbitMQClient (ContextServiceLocator contextServiceLocators) {
      contextServiceLocator = contextServiceLocators;
    }
    public void CreateConnectionAsync (string HostName, string UserName, string Password, int port) {
      _factory = new ConnectionFactory {
        HostName = HostName,
        UserName = UserName,
        Password = Password,

      };
      try {
        _connection = _factory.CreateConnection ();
        _model = _connection.CreateModel ();
      } catch (ArgumentException) {
        return;
      } catch (ConnectFailureException) {
        return;
      } catch (BrokerUnreachableException) {
        return;
      }
    }
    public void Close () {
      _connection.Close ();
    }
    public void createQueue (string nomeQueue, string nomeExchange, string acao) {
      var route = $"{nomeQueue}.{acao}";
      _model.QueueDeclare (nomeQueue, true, false, false, null);
      _model.QueueBind (nomeQueue, nomeExchange, route);
    }
    public void createExchange (string nomeExchange) {
      _model.ExchangeDeclare (nomeExchange, "topic");
    }
    //Pegar os valores que estão no RabbitMQ
    public TModel Send<TModel> (string nomeExchange, string nomeQueue, string acao, TModel model)
    where TModel : class {
      var route = $"{nomeQueue}.{acao}";
      _model.ExchangeDeclare (nomeExchange, "topic");
      _model.BasicPublish (nomeExchange, route, null, model.Serialize ());
      return default;
    }
    public string Receive (System.Type type, string name) {
      var consumer = new EventingBasicConsumer (_model);
      for (var n = 0; n < 1; n++) {
        consumer.Received += (model, ea) => {
          if (n ==0) {
            var body = ea.Body.ToArray ();
            message = Encoding.UTF8.GetString (body);
            if (message != null) {
              if (n == 0) {
                _model.BasicAck (ea.DeliveryTag, true);
              }
              t++;
            }
          }

        };
        _model.BasicConsume (queue: name, autoAck: true, consumer: consumer);

      }
      //_model.BasicAck(ea.DeliveryTag, false);
      // var consumer = new QueueingBasicConsumer(_model);
      return message;

    }

    public bool CheckConn (string HostName, string UserName, string Password, int port) {
      CreateConnectionAsync (HostName, UserName, Password, port);
      if (_connection != null)
        return true;
      else
        return false;
    }

  }
}