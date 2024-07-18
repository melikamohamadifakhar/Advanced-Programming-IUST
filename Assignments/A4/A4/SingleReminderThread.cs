using System;
using System.Threading;
using System.Threading.Tasks;

namespace A4
{
    public class SingleReminderThread : ISingleReminder
    {

        public SingleReminderThread(string msg, int delay){
            this.Msg = msg;
            this.Delay = delay;
        }
        public int Delay{get; private set;}

        public string Msg{get; private set;}

        public event Action<string> Reminder;

        public void Start()
        {
            Thread thread = new Thread(()=>
            {
                Reminder(Msg);
            });
            Thread.Sleep(Delay);
            thread.Start();
        
        }
    }
}