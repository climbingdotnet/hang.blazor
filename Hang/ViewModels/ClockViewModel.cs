using Hang.ViewModels.Interface;
using Microsoft.JSInterop;
using System;
using System.ComponentModel;
using System.Timers;

namespace Hang.ViewModels
{
    public class ClockViewModel : IClockViewModel
    {
        private int reps;
        private int hangSeconds;
        private int restSeconds;
        private bool countDown;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Action { get; set; }
        public int Rep { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public TimeSpan ActionTime { get; set; }
        public Timer Timer { get; set; }

        public void OnInit(int hangSeconds, int restSeconds, int reps)
        {
            Action = string.Empty;
            TimeRemaining = new TimeSpan();
            Rep = 0;
            ActionTime = new TimeSpan();

            this.hangSeconds = hangSeconds;
            this.restSeconds = restSeconds;
            this.reps = reps;

            RunClock();
        }

        public void RunClock()
        {
            Timer = new Timer(100);
            Timer.Elapsed += HandleTimerElapsed;

            countDown = true;
            TimeRemaining = TimeSpan.FromSeconds(((hangSeconds + restSeconds) * reps) - restSeconds);
            ActionTime = TimeSpan.FromSeconds(3); // countDown
            Action = string.Empty;

            Timer.Start();
        }

        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ActionTime = ActionTime.Add(TimeSpan.FromMilliseconds(-100));
            if (!countDown) TimeRemaining = TimeRemaining.Add(TimeSpan.FromMilliseconds(-100));

            if (TimeRemaining.TotalSeconds <= 0)
            {
                ActionTime = TimeSpan.FromSeconds(0);
                TimeRemaining = TimeSpan.FromSeconds(0);

                Action = "Done!";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClockViewModel)));
                Timer.Stop();
            }
            else if (ActionTime.TotalSeconds < TimeSpan.FromSeconds(0).TotalSeconds)
            {
                if (Action.Equals("Hang"))
                {
                    Action = "Rest";
                    ActionTime = TimeSpan.FromSeconds(restSeconds);
                }
                else
                {
                    Rep = Rep + 1;
                    countDown = false;
                    Action = "Hang";
                    ActionTime = TimeSpan.FromSeconds(hangSeconds);
                }
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClockViewModel)));
        }
    }
}
