using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TreeView.Helpers.MVVM
{
    public class RelayCommand<T> : ICommand
    {
        protected Action<T> _execute;
        protected Func<T, bool> _canExecute;

        protected RelayCommand() { }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (p => true);
        }

        public RelayCommand(Action<T> execute) : this(execute, (Func<T, bool>)null) { }
        public RelayCommand(Action<T> execute, Func<bool> canExecute) : this(execute, p => canExecute()) { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) => _execute((T)parameter);
        public bool CanExecute(object parameter) => _canExecute((T)parameter);
    }

    public class RelayCommand : RelayCommand<object>
    {
        private Action<Collection<object>> delete;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute) : base(execute, canExecute) { }

        public RelayCommand(Action execute) : base(p => execute()) { }
        public RelayCommand(Action execute, Func<bool> canExecute) : base(p => execute(), p => canExecute()) { }

        public RelayCommand(Action<object> execute) : base(execute) { }
        public RelayCommand(Action<object> execute, Func<bool> canExecute) : base(execute, canExecute) { }

        public RelayCommand(Action<Collection<object>> delete)
        {
            this.delete = delete;
        }
    }
}
