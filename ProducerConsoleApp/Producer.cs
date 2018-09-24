using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace ProducerConsoleApp
{
    public class Producer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            var producer = new Producer();

            if (!producer.ValidateInput(name))
            {
                Console.WriteLine(" Name should be only Alphabets no numbers or special characters allowed.");
                Console.ReadLine();
                return;
            }

            var message = "Hello my name is," + name;
            producer.SendMessage(message);

            Console.ReadLine();
        }

        //Validates the input name contains only alphabets
        public bool ValidateInput(string input)
        {
            //input should not be Empty string
            if (string.IsNullOrEmpty(input))
                return false;

            //Input should contain only alphabets
            var result = input.All(Char.IsLetter);

            return result;
        }

        public void SendMessage(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "testqueue",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: "testqueue",
                                             basicProperties: null,
                                             body: body);
                        Console.WriteLine("Sent Message: {0}", message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured, ", ex.Message);
            }
        }
    }
}
