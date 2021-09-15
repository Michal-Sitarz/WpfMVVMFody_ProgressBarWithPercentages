using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TestMVVM.Commands;

namespace TestMVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public int ProgressStatus { get; set; }
        public int ProgressStatusInPercents { get; set; }
        public int Max { get; set; }

        private int onePercent;
        private int valueInPercentEquivalent;

        //public ICommand UpdateIt { get; private set; }

        public MainWindowViewModel()
        {
            //UpdateIt = new RelayCommand();
            ProgressStatus = 0;
            Max = 100000000;
            onePercent = Max / 100;
        }


        public void Go()
        {
            for (int i = 0; i <= Max; i++)
            {
                ProgressStatus = i;
                if (i > valueInPercentEquivalent)
                {
                    ProgressStatusInPercents++;
                    valueInPercentEquivalent += onePercent;
                }
            }

        }

    }
}
