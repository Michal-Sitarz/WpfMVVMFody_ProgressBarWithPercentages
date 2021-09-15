using System;
using System.Windows.Input;

namespace TestMVVM.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly string _callerName;

        public RelayCommand(Action<object> execute, string callerName)
        {
            _execute = execute;
            _callerName = callerName;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            // TODO: add try/catch/finally and log errors

            _execute(parameter);
        }
    }
}
