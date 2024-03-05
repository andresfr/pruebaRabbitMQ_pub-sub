﻿using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory {     HostName = "localhost",     UserName = "user",    Password = "password"};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello2",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

const string message = "prueba lunes medio dia 4";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: string.Empty,
                     routingKey: "hello2",
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();