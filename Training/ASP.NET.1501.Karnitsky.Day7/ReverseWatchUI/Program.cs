using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ReverseWatch;

namespace ReverseWatchUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Watch rw = new Watch();                      

            SubscribeManager.SubscribeAll(new SubscriberNo1(rw), new SubscriberNo2(rw));            

            rw.StartWatch(1000, 1000, "repeat timer"); 
            Thread.Sleep(3000);
            
            rw.StartWatch(1000, "once time call event");
            Thread.Sleep(500);

            Thread.Sleep(5000);           

            SubscribeManager.UnsubscribeAll(); 

            Console.ReadLine();
        }
    }
}
