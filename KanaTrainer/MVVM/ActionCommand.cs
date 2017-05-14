using System;
using System.Windows.Input;

namespace MaximStartsev.KanaTrainer.MVVM
{
    public sealed class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool? _currentCanExecute = null;
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public ActionCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var canExecute = _canExecute(parameter);
            if(_currentCanExecute != null && _currentCanExecute != canExecute)
            {
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
            _currentCanExecute = canExecute;
            return canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
