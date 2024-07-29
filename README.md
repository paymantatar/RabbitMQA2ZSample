# RabbitMQ Sample
Sample and quick way of using Message que with .Net8.

## Event-Driven Architecture
This communication type microservices don't call each other, instead of that they created events and consume events from message broker systems in an async way. In this section we will follow this type of communication for Basket microservice Publish BasketCheckout Queue with RabbitMQ
Ordering Microservice Consuming RabbitMQ BasketCheckout event queue with using RabbitMQ Configuration.
Note: The best tools for next level is composition of [MassTransit] (https://masstransit.io/quick-starts/rabbitmq) with RabbitMQ or other messaging tools like (RabbitMQ/ MSMQ, Azure service bus, Amazon SQS ).


### Benefits 
The producer service of the events does not know about its consumer services. On the other hand, the consumers also do not necessarily know about the producer. As a result, services can deploy and maintain independently. This is a key requirement to build loosely coupled microservices.

## Prerequisites

Before you begin, ensure you have the following tools installed:

- Visual Studio (with .NET SDK)
- [Dotnet8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [.netcore for Linux](https://www.microsoft.com/net/core)
- [RabbitMQ](https://www.nuget.org/packages/RabbitMQ.Client)

## About RabbitMQ
What is RabbitMQ?

In essence, RabbitMQ is a message broker — a middleman that makes it easier for messages to be exchanged between various components of a distributed application. It serves as a mediator, enabling decoupled and asynchronous communication between the various parts of your program.

Why Use RabbitMQ?

Decoupling Components: In a distributed system, components often need to interact with each other, but tying them together tightly can lead to issues. RabbitMQ enables loose coupling by allowing components to communicate via messages. This separation of concerns makes your application more maintainable and flexible.
Asynchronous Communication: RabbitMQ supports asynchronous messaging, which means that senders and receivers of messages don’t need to be active simultaneously. This promotes responsiveness and scalability in your application.
Load Leveling: In scenarios where some components of your application may be overwhelmed while others are idle, RabbitMQ helps distribute workloads evenly, preventing bottlenecks.
Fault Tolerance: RabbitMQ provides features for ensuring fault tolerance. Messages can be persisted, and configurations can be set up to handle system failures gracefully.
Key Concepts in RabbitMQ

To understand RabbitMQ fully, it’s essential to grasp several key concepts:
Building web applications that can manage rising loads and changing user expectations is not just a goal, it’s a need in today’s digital world. Your ASP.NET Core apps must be scalable in order to maintain responsiveness and performance as your user base expands. RabbitMQ message queues are one effective weapon in your armory for attaining scalability. we’ll look at how to use RabbitMQ message queues to create ASP.NET Core apps that are incredibly scalable.

Understanding RabbitMQ
Messaging is crucial in the world of distributed systems and scalable applications for allowing communication between diverse parts and services. Open-source message broker RabbitMQ has become a potent tool in this field. 

## Key Concepts in RabbitMQ

To understand RabbitMQ fully, it’s essential to grasp several key concepts:

* Message: Messages are units of data that are sent from a producer (sender) to a consumer (receiver) via RabbitMQ. They contain information that components need to communicate.
* Producer: A producer is a component that sends messages to RabbitMQ. Producers generate messages and dispatch them to the message broker.
*  Consumer: A consumer is a component that receives and processes messages from RabbitMQ. Consumers subscribe to queues and wait for messages to arrive.
* Queue: A queue is a data structure in RabbitMQ where messages are stored. Queues act as buffers between producers and consumers. Messages are placed in a queue by producers and retrieved by consumers.
* Exchange: An exchange is an entity in RabbitMQ that determines how messages are routed to queues. Exchanges receive messages from producers and route them to the appropriate queue(s) based on predefined rules.
* Binding: A binding is a rule that connects an exchange to a queue. It specifies which queue(s) will receive messages from a particular exchange.
* Routing Key: In some messaging patterns, messages are routed to queues based on a routing key. The routing key is a property of the message that is used by exchanges to determine the destination queue(s).
* Publisher-Subscriber Pattern: RabbitMQ supports the publisher-subscriber pattern, where multiple consumers can subscribe to the same queue and receive copies of the messages. This is useful for implementing broadcasting and fan-out scenarios.
* DeadLetterQue:
Messages from a queue can be "dead-lettered", which means these messages are republished to an exchange when any of the following four events occur.

The message is negatively acknowledged by a consumer using basic.reject or basic.nack with requeue parameter set to false, or
The message expires due to per-message TTL, or
The message is dropped because its queue exceeded a length limit, or
The message is returned more times to a quorum queue than the delivery-limit.
RabbitMQ is a versatile and trustworthy message broker that streamlines communication between distributed systems. By offering asynchronous, decoupled messaging, RabbitMQ aids programmers in creating scalable, responsive, and fault-tolerant applications. We’ll go over setting up RabbitMQ and exploiting its capabilities to create scalable ASP.NET Core apps in the sections that follow.
* LazyQue: 
A "lazy queue" is a classic queue which is running in lazy mode. When the "lazy" queue mode is set, messages in classic queues are moved to disk as early as practically possible. These messages are loaded into RAM only when they are requested by consumers.



## Getting Started

1. Clone this repository:

   ```bash
   git clone https://github.com/paymantatar/RabbitMQA2ZSample.git
   ```

2. Install dependencies:

   ```bash
   dotnet restore
   ```

3. Build the solution:

   ```bash
   dotnet build
   ```
4. pull your RabbitMQ from DockerHub
https://hub.docker.com/_/rabbitmq/tags
Select your Ideal version based on your chosen docker pull rabbitmq:3.13.4-management
Set up your Docker for local development: (Tips: for Windows OS you Need docker desktop!)
Then: docker run -d --name rabbit -p 15672:15672 -p 5672:5672 -e RABBITMQ_DEFAULT_USER=Useradmin -e RABBITMQ_DEFAULT_PASS=pass***word rabbitmq:3.13.4-management

## Technologies Used

* <a href="https://github.com/rabbitmq/rabbitmq-dotnet-client" target="_blank">GitHub:RabbitMQ</a>
* <a href="https://dotnet.microsoft.com/en-us/apps/aspnet" target="_blank">ASP.NET Core</a>
* <a href="https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection" target="_blank">.NET Core Native DI</a>
* <a href="https://www.rabbitmq.com/" target="_blank">RabbitMQ</a>
* <a href="https://masstransit.io/quick-starts/rabbitmq" target="_blank">Masstransit with RabbitMQ</a>
* <a href="https://learn.microsoft.com/en-us/ef/core/" target="_blank">Entity Framework Core</a>
* <a href="https://nlog-project.org/" target="_blank">NLog</a>


