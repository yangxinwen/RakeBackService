using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Services;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(RakeBackService));
            serviceHost.Open();
            while (true)
            {
                Thread.Sleep(10 * 1000);
            }
        }
    }
}
