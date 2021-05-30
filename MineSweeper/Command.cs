using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MineSweeper
{
    public class Command : ICommand
    {
        private Action<object> execution;
        public event EventHandler CanExecuteChanged;

        public bool IsActive = true;

        public Command(Action<object> Execution)
        {
            execution = Execution;
        }

        public bool CanExecute(object parameter)
        {
            return IsActive;
        }

        public void Execute(object parameter)
        {
            execution(parameter);
        }
    }
}
