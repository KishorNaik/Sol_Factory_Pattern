using Sol_Demo.Concrete;
using Sol_Demo.Cores;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Factory
{
    public enum ConcreteType
    {
        Mail = 0,
        SMS = 1
    };

    public sealed class FactorySend
    {
        private readonly ConcurrentDictionary<ConcreteType, Lazy<ISend>> keyValuePairs = new ConcurrentDictionary<ConcreteType, Lazy<ISend>>();

        private readonly Task initializingTask = null;

        public FactorySend() => initializingTask = SetFactoriesAsync();

        private Task SetFactoriesAsync()
        {
            return Task.Run(() =>
            {
                keyValuePairs.TryAdd(ConcreteType.Mail, new Lazy<ISend>(() => new Mail()));
                keyValuePairs.TryAdd(ConcreteType.SMS, new Lazy<ISend>(() => new Sms()));
            });
        }

        public async Task<ISend> ExecuteAsync(ConcreteType concreteType)
        {
            await initializingTask;

            return keyValuePairs[concreteType].Value;
        }
    }
}