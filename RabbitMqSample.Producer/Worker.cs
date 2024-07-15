using RabbitMQ.Client;
using RabbitMqSample.Model;
using System.Text;
using System.Text.Json;

namespace RabbitMqSample.Producer;

public class Worker(ILogger<Worker> logger, IModel channel) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			if (logger.IsEnabled(LogLevel.Information))
			{
				logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
			}

			var data = new SampleContract
			{
				Id = 1,
				Title = "Test"
			};

			var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));

			channel.BasicPublish(exchange: "sample-exchange",
				routingKey: "sample-routingkey-" + DateTime.Now.Second % 2,
				body: body);


			await Task.Delay(1000, stoppingToken);
		}
	}
}

