using System;
using Case00020692.Messages.Commands;
using NServiceBus;

namespace Case00020692
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the connection string and press enter");
            var connectionString = Console.ReadLine();

            var config = new BusConfiguration();
            config.EndpointName("Case00020692");

            config.UseTransport<AzureServiceBusTransport>()
                .ConnectionString(() => connectionString);

            config.UseSerialization<JsonSerializer>();

            config.Transactions()
                .DisableDistributedTransactions()
                .WrapHandlersExecutionInATransactionScope();

            config.Conventions()
                .DefiningCommandsAs(el => el.Namespace != null && el.Namespace.EndsWith("Commands"));

            config.PurgeOnStartup(false);

            config.UsePersistence<InMemoryPersistence>();

            var bus = Bus.Create(config);

            bus.Start();

            bus.SendLocal(new MyCommand() {Id = Guid.NewGuid() });

            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
    }
}
