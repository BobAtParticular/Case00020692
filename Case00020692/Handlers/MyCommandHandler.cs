using System;
using Case00020692.Messages.Commands;
using NServiceBus;

namespace Case00020692.Handlers
{
    public class MyCommandHandler : IHandleMessages<MyCommand>
    {
        public void Handle(MyCommand message)
        {
            Console.WriteLine($"Message with Id {message.Id} handled.");
        }
    }
}
