using Sol_Demo.Cores;
using Sol_Demo.Factory;
using System;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                FactorySend factory = new FactorySend();

                // To Send Mail
                ISend sendMail = await factory?.ExecuteAsync(ConcreteType.Mail);
                await sendMail.SendMessage("Hello Mail");

                // To Send SMS
                ISend sendSms = await factory?.ExecuteAsync(ConcreteType.SMS);
                await sendMail.SendMessage("Hello SMS");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}