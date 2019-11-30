using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleGraphGenerator.ViewModels.Commands
{
    class SimpleCommand : ICommand
    {
        public SimpleCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        private Action _executeAction;

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _executeAction();
        }
    }
}
