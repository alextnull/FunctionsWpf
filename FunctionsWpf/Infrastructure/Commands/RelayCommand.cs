using System;

namespace FunctionsWpf.Infrastructure.Commands
{
    internal class RelayCommand : CommandBase
    {
        /// <summary>
        /// Указывает на метод, который необходимо вызвать при выполнении команды. 
        /// Параметр object представляет параметр команды.
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Указывает на метод, который необходимо вызвать для проверки доступности выполнения команды. 
        /// Параметр object представляет параметр команды./// </summary>
        /// <returns>Возвращает true если команду можно выполнить, иначе false.</returns>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Инициализирует внутренние делегаты переданными методами для выполнения команды и проверки доступности выполнения команды соответственно.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Проверяет возможно ли выполнить команду.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Если команду можно выполнить или метод проверки не был передан в конструктор, тогда возвращает true, иначе false</returns>
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter) => _execute(parameter);
    }
}
