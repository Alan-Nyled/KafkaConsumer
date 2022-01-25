using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "172.19.95.154:9092",
    GroupId = "Gruppe",
    AutoOffsetReset = AutoOffsetReset.Latest,
};

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("quickstart-events");

    Console.WriteLine("Klar til at modtage beskeder");

    while (true)
    {
        var consumeResult = consumer.Consume();
        string message = consumeResult.Message.Value;

        Console.WriteLine($"Besked modtaget: {message}");
    }
    consumer.Close();
}