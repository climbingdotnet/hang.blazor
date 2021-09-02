using System;
using System.ComponentModel;
using System.Timers;

namespace Hang.ViewModels.Interface
{
    public interface IClockViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        public int Rep { get; set; }
        string Action { get; set; }
        TimeSpan TimeRemaining { get; set; }
        TimeSpan ActionTime { get; set; }
        Timer Timer { get; set; }
        void OnInit(int hangSeconds, int restSeconds, int reps);
        void RunClock();

    }
}
