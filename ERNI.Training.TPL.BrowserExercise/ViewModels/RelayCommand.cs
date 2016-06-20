using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERNI.Training.TPL.BrowserExercise.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeHandler;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> executeHandler, Func<object, bool> canExecute)
        {
            if (executeHandler == null)
            {
                throw new ArgumentNullException(nameof(executeHandler));
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }

            _executeHandler = executeHandler;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _executeHandler.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
    }
}
