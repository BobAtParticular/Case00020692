using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Case00020692
{
    class ConfigErrorQueue :
        IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }
}