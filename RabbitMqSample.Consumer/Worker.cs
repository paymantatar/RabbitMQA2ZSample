using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqSample.Model;
using System.Text;
using System.Text.Json;

namespace RabbitMqSample.Consumer;

public class Worker(ILogger<Worker> logger, IModel channel) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var consumerSample1 = new EventingBasicConsumer(channel);

		consumerSample1.Received += (_, eventArgs) =>
		{
			var deliveryTag = eventArgs.DeliveryTag;

			var messageBody = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

			var message = JsonSerializer.Deserialize<SampleContract>(messageBody);

			logger.LogInformation($"From Sample 1 => {Environment.NewLine} {messageBody}");

			channel.BasicAck(deliveryTag, false);
		};

		channel.BasicConsume(queue: "sample1",
			consumer: consumerSample1);



		var consumerSample2 = new EventingBasicConsumer(channel);

		consumerSample2.Received += (_, eventArgs) =>
		{
			var deliveryTag = eventArgs.DeliveryTag;

			var messageBody = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

			var message = JsonSerializer.Deserialize<SampleContract>(messageBody);

			logger.LogInformation($"From Sample 2 => {Environment.NewLine} {messageBody}");

			channel.BasicAck(deliveryTag, false);
		};

		channel.BasicConsume(queue: "sample2",
			consumer: consumerSample2);
	}
}
