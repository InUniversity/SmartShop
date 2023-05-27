using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartShop.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand<T> : ICommand
    {

        private readonly Action<T> exeAction;
        private readonly Predicate<T> canExeAction;
        private Action<string> executeDeleteProd;

        public RelayCommand(Action<T> exeAction)
        {
            this.exeAction = exeAction;
            canExeAction = null;
        }

        public RelayCommand(Action<string> executeDeleteProd)
        {
            this.executeDeleteProd = executeDeleteProd;
        }

        public RelayCommand(Action<T> exeAction, Predicate<T> canExeAction)
        {
            this.exeAction = exeAction;
            this.canExeAction = canExeAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return canExeAction == null ? true : canExeAction((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            exeAction((T)parameter);
        }
    }
}
