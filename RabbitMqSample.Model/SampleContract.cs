namespace RabbitMqSample.Model;

public class SampleContract
{
	public int Id { get; set; }

	public string? Title { get; set; }

	public Guid CorrelationId { get; set; } = Guid.NewGuid();
}

// SAGA Pattern

// System A => System B => System C(Error) => System D 

// Post Api => Mesaage,Header,Target,MessageType(R,D)

// Client => IDP(1),Subsystem2(2)

// SMS,Email,Slack,SignalR

// A) 15 min  , B) 30 min ,  C) 4 Hour   D) Dead-Letter

// Main Queue           =>     1,2,3(Error),4,5
// Dead-Letter Queue    =>     3 (Log and Drop - Consume)

// LoadBalancer (RabbitMq => C#/ Apache Kafka => zookeeper) => Message Type and Load Balance Policy(Round-Robin / Min-Response / Min-Connection / Queue-Count / Message-Count)
// Agent A => SMS,Email
// Agent B => SMS
// Agent C => Email
