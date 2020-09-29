using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public interface ISend
    {
        Task SendMessage(string body);
    }
}