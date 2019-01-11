using System;
using System.Windows.Input;

namespace Biblio.ViewModel
{
    public class CommandDelegate : ICommand
    {
        Action<object> ExecuteDelegate;
        Func<object, bool> CanExecuteDelegate;
        private Func<object, bool> p;

        public CommandDelegate(Func<object, bool> canExecuteDelegate,
            Action<object> executeDelegate)
        {
            this.CanExecuteDelegate = canExecuteDelegate;
            this.ExecuteDelegate = executeDelegate;
        }

        public CommandDelegate(Func<object, bool> p)
        {
            this.p = p;
        }

        public event EventHandler CanExecuteChanged;

        public void ChangedCanExecute()
        {
            var Handler = CanExecuteChanged;
            Handler?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            var Handler = CanExecuteDelegate;
            bool Result = false;
            if (Handler != null)
            {
                Result = Handler(parameter);
            }
            return Result;
        }

        public void Execute(object parameter)
        {
            var Handler = ExecuteDelegate;
            Handler?.Invoke(parameter);
        }
    }
}
