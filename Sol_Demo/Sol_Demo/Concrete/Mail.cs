using Sol_Demo.Cores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Concrete
{
    internal class Mail : ISend
    {
        Task ISend.SendMessage(string body)
        {
            return Task.Run(() => Console.WriteLine(body));
        }
    }
}