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

        // using GetAwaiter().GetResult() method
        //public FactorySend() => this.SetFactoriesAsync().GetAwaiter().GetResult();

        // Or

        // using Task.WaitAlll() method
        public FactorySend() => Task.WaitAll(this.SetFactoriesAsync());

        private Task SetFactoriesAsync()
        {
            return Task.Run(() =>
            {
                keyValuePairs.TryAdd(ConcreteType.Mail, new Lazy<ISend>(() => new Mail()));
                keyValuePairs.TryAdd(ConcreteType.SMS, new Lazy<ISend>(() => new Sms()));
            });
        }

        public Task<ISend> ExecuteAsync(ConcreteType concreteType)
        {
            return Task.Run(() =>
            {
                return keyValuePairs[concreteType].Value;
            });
        }
    }
}