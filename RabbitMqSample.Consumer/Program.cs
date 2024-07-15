using RabbitMQ.Client;
using RabbitMqSample.Consumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var connectionFactory = new ConnectionFactory
{
	HostName = builder.Configuration["RabbitMQ:Host"],
	UserName = builder.Configuration["RabbitMQ:Username"],
	Password = builder.Configuration["RabbitMQ:Password"],
	VirtualHost = builder.Configuration["RabbitMQ:VirtualHost"],
	Port = int.Parse(builder.Configuration["RabbitMQ:Port"]!)
};
var connection = connectionFactory.CreateConnection();

builder.Services.AddSingleton(_ => connection.CreateModel());

var host = builder.Build();
await host.RunAsync();