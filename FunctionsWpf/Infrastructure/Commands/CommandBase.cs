using System;
using System.Windows.Input;

namespace FunctionsWpf.Infrastructure.Commands
{
    /// <summary>
    /// Абстрактный базовый класс команд, который реализует интерфейс ICommand.
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        #region События

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Методы

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        #endregion
    }
}
