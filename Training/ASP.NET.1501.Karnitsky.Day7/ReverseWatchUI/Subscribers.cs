using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseWatch;

namespace ReverseWatchUI
{
    public static class SubscribeManager
    {
        private static ISubscriber[] _subscribers;
        
        public static void SubscribeAll(params ISubscriber[] subscribers)
        {
            _subscribers = subscribers;
            foreach(ISubscriber sb in subscribers)
            {
                sb.SubscribeEvent();
            }
        }

        public static void UnsubscribeAll()
        {
            foreach (ISubscriber sb in _subscribers)
            {
                sb.UnsubscribeEvent();
            }
        }   
    }
   
    class SubscriberNo1 : ISubscriber
    {
        private Watch rw;

        public SubscriberNo1(Watch rw)
        {
            this.rw = rw;
        }

        public void SubscribeEvent()
        {
            rw.TimeOut += TimeOut;
        }
        public void UnsubscribeEvent()
        {
            rw.TimeOut -= TimeOut;
        }

        void TimeOut(object sender, ReverseWatchEventArgs e)
        {
            Console.WriteLine("Subscriber #1: " + e.Message);
        }
    }

    class SubscriberNo2 : ISubscriber
    {
        private Watch rw;

        public SubscriberNo2(Watch rw)
        {
            this.rw = rw;
        }

        public void SubscribeEvent()
        {
            rw.TimeOut += TimeOut;
        }

        public void UnsubscribeEvent()
        {
            rw.TimeOut -= TimeOut;
        }

        void TimeOut(object sender, ReverseWatchEventArgs e)
        {
            Console.WriteLine("Subscriber #2: " + e.Message);
        }
    }

}
