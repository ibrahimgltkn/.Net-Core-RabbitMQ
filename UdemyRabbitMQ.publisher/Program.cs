using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Shared;
using System.Text.Json;

namespace UdemyRabbitMQ.subscriber

{
    public enum LogNames
    {
        Critical = 1,
        Error = 2,
        Warning = 3,
        Information = 4
    }
    class Program

    {

        static void Main(string[] args)

        {

            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqps://xamvorlj:egq8D25937OxGj2dAUDgLOU4DYfxHv_p@toad.rmq.cloudamqp.com/xamvorlj");


            using var connection = factory.CreateConnection();


            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);

            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);


            Dictionary<string, object> headers = new Dictionary<string, object>();

            headers.Add("format", "pdf");
            headers.Add("shape", "a4");

            var properties = channel.CreateBasicProperties();
            properties.Headers = headers;
            properties.Persistent = true;

            var product = new Product { Id = 1, Name = "Kalem", Price = 100, Stock = 10 };

            var productJsonString = JsonSerializer.Serialize(product);

            channel.BasicPublish("header-exchange",string.Empty,properties,Encoding.UTF8.GetBytes(productJsonString));

            Console.WriteLine("mesaj gönderildi");

            Console.ReadLine();




        }

    }

}