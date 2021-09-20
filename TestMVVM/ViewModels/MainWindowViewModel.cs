using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using TestMVVM.Commands;

namespace TestMVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public int ProgressStatus { get; set; }
        public int ProgressStatusInPercents { get; set; }
        public int Max { get; set; }
        public string TimerStatus { get; set; } = "00:00.00";

        private int onePercent;
        private int valueInPercentEquivalent;

        private DispatcherTimer timer;
        private Stopwatch stopwatch;

        //public ICommand UpdateIt { get; private set; }

        public MainWindowViewModel()
        {
            //UpdateIt = new RelayCommand();

            // progress status
            ProgressStatus = 0;
            Max = 10000000; // Max cannot be less than 100
            onePercent = Max / 100;

            // timer
            stopwatch = new Stopwatch();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }


        public void Go()
        {
            ResetValues();

            TimerStart();
            for (int i = 0; i <= Max; i++)
            {
                ProgressStatus = i;
                if (i > valueInPercentEquivalent)
                {
                    ProgressStatusInPercents++;
                    valueInPercentEquivalent += onePercent;
                }
            }
            TimerStop();
        }

        private void ResetValues()
        {
            ProgressStatus = 0;
            ProgressStatusInPercents = 0;
            valueInPercentEquivalent = 0;

            TimerReset();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                //TimerStatus = ts.ToString();
                //TimerStatus = string.Format("{0:00}:{1:00}:{2:00}",ts.Hours,ts.Minutes,ts.Seconds);
                TimerStatus = string.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }
        }

        private void TimerStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        private void TimerStop()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        private void TimerReset()
        {
            stopwatch.Reset();
            TimerStatus = "";
        }

    }
}
