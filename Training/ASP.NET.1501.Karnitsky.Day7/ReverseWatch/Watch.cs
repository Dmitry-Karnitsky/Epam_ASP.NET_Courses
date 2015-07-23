using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReverseWatch
{
    public class Watch
    {
        private Timer tm;
        public event EventHandler<ReverseWatchEventArgs> TimeOut;
        public void StartWatch(long milliseconds, string message)
        {
            StartWatch(milliseconds, Timeout.Infinite, message);
        }
        
        public void StartWatch(long milliseconds, long period, string message)
        {     
            ReverseWatchEventArgs e = new ReverseWatchEventArgs(message);
            tm = new Timer(TimerCallback, e, milliseconds, period);
        }         

        private void TimerCallback(object obj)
        {
            OnTimeOut((ReverseWatchEventArgs)obj);
        }

        protected virtual void OnTimeOut(ReverseWatchEventArgs e)
        {
            e.Raise<ReverseWatchEventArgs>(this, ref TimeOut);            
        }  
    }

    internal static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e,
        Object sender, ref EventHandler<TEventArgs> eventDelegate) where TEventArgs : EventArgs
        {
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
            if (temp != null) temp(sender, e);
        }
    }

    public class ReverseWatchEventArgs : EventArgs
    {
        private readonly string message;
        public ReverseWatchEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        { get { return message; } }
    }

}
