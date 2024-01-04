using FileCreateWorkerService;
using FileCreateWorkerService.Models;
using FileCreateWorkerService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;


        services.AddDbContext<AdventureWorks2019Context>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        
        services.AddSingleton<RabbitMQClientService>();
        services.AddHostedService<Worker>();

        services.AddSingleton<ConnectionFactory>(sp =>
        {
            var connectionString = configuration.GetConnectionString("RabbitMQ");
            var factory = new ConnectionFactory() { Uri = new Uri(connectionString), DispatchConsumersAsync = true };
            return factory;
        });

    })
    .Build();

host.Run();

