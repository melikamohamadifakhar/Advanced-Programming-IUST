using System;
using System.Threading;

namespace A4
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public SingleReminderThreadPool(string msg, int delay){
            this.Delay = delay;
            this.Msg = msg;
        }
        public int Delay{get; private set;}

        public string Msg{get; private set;}

        public event Action<string> Reminder;

        public void Start()
        {
            Thread.Sleep(this.Delay);
            ThreadPool.QueueUserWorkItem(new WaitCallback((msg)=>
            {
                Reminder(Msg);
            }));
        }
    }
}