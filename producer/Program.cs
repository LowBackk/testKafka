using Confluent.Kafka;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092" // Use Kafka broker address here
        };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                // Send a message to the Kafka topic
                var deliveryResult = await producer.ProduceAsync("AuthLogin", new Message<Null, string>
                {
                    Value = "Hello, Kafka from .NET!"
                });

                Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                // Send a message to the Kafka topic
                var deliveryResult = await producer.ProduceAsync("AuthRegister", new Message<Null, string>
                {
                    Value = "Hello, Kafka from .NET!"
                });

                Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}