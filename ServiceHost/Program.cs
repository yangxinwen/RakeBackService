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
            Console.WriteLine("---------------服务已启动-------------   "+DateTime.Now.ToString());

            //var service = new RakeBackService();
            //var result=service.RequestUpdateInfo("1.0.0");

            while (true)
            {
                Thread.Sleep(1000 * 1000);
            }
        }
    }
}
