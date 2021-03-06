using System;

namespace FunctionsWpf.Infrastructure.Commands
{
    /// <summary>
    /// Основной класс для всех команд
    /// </summary>
    internal class RelayCommand : CommandBase
    {
        #region Делегаты

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

        #endregion

        #region Методы

        /// <summary>
        /// Проверяет возможно ли выполнить команду.
        /// </summary>
        /// <param name="parameter">Параметр команды<./param>
        /// <returns>Если команду можно выполнить или метод проверки не был передан в конструктор, тогда возвращает true, иначе false.</returns>
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public override void Execute(object parameter) => _execute(parameter);

        #endregion

        #region Конструктор

        /// <summary>
        /// Инициализирует делегаты команды переданными методами при выполнении команды и проверки доступности выполнения команды соответственно.
        /// </summary>
        /// <param name="execute">Ссылка на метод, вызываемый при выполнении команды.</param>
        /// <param name="canExecute">Ссылка на метод, вызываемый для проверки доступности команды.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion
    }
}
