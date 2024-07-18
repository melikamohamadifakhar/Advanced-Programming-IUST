using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace A4
{
    public class SingleReminderTask : ISingleReminder
    {
        public SingleReminderTask(string msg, int delay){
            this.Delay = delay;
            this.Msg = msg;
        }
        public int Delay{get; set;}

        public string Msg{get; set;}

        public event Action<string> Reminder;

        public void Start()
        {
            Task.Delay(this.Delay).ContinueWith((msg)=>
            {
                this.Reminder(Msg);
            });
        }
    }
}