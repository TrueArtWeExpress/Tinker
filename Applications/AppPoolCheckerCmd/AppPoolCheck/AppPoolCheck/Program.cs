using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Timers;
using System.Data.Objects;
using System.Configuration;
using System.Threading.Tasks;
using System.ComponentModel.Design;


namespace AppPoolCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            const double interval60Minutes = 5 * 5 * 1000; // milliseconds to one hour
            Timer checkForTime = new Timer(interval60Minutes);
            checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkForTime.Enabled = true;
            Console.WriteLine("Waiting..");
            Console.ReadLine();
        }

        public static void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            GetApplicationPoolNames();
        }

        public static string GetApplicationPoolNames()
        {
            ServerManager manager = new ServerManager();
            string status;
            //string DefaultSiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            //Site defaultSite = manager.Sites[DefaultSiteName];
            string appVirtaulPath = HttpRuntime.AppDomainAppVirtualPath;
            string mname = System.Environment.MachineName;
            string appPoolName = string.Empty;
            manager = ServerManager.OpenRemote(mname);
            ObjectState result = ObjectState.Unknown;

            ApplicationPoolCollection applicationPoolCollection = manager.ApplicationPools;

            foreach (ApplicationPool applicationPool in applicationPoolCollection)
            {
                //result = manager.ApplicationPools[appPoolName].State;
                result = applicationPool.State; // here exception occures*
                Console.WriteLine("State : " + result);
                Console.ReadLine();
            }
        }

    }
}
