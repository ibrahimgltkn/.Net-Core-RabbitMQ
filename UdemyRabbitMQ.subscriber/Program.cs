// RabbitMQ.Client kütüphanesini kullanarak RabbitMQ'ya bağlantı kurmak ve mesajları almak için gerekli kodlar.

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;
using System;
using System.Text;
using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {

        var factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://xamvorlj:egq8D25937OxGj2dAUDgLOU4DYfxHv_p@toad.rmq.cloudamqp.com/xamvorlj");

        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();
        channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);

        channel.BasicQos(0, 1, false);



        var consumer = new EventingBasicConsumer(channel);

        var queueName = channel.QueueDeclare().QueueName;

        Dictionary<string, object> headers = new Dictionary<string, object>();

        headers.Add("format", "pdf");
        headers.Add("shape", "a4");
        headers.Add("x-match", "any");



        channel.QueueBind(queueName, "header-exchange",string.Empty,headers);

        channel.BasicConsume(queueName, false, consumer);



        Console.WriteLine("Loglar dinleniyooor...");

        consumer.Received += (object sender, BasicDeliverEventArgs e) =>
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            Product product = JsonSerializer.Deserialize<Product>(message);

            Thread.Sleep(1000);

            Console.WriteLine($"Gelen Mesaj :  {product.Id }-{ product.Name } -{ product.Price}-{product.Stock}");

            channel.BasicAck(e.DeliveryTag, false);
        };

        // Konsol uygulamasının kapatılmasını bekliyor.
        Console.ReadLine();
    }
}