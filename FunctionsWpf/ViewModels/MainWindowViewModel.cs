using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunctionsWpf.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged при изменении свойста класса.
        /// </summary>
        /// <param name="property">Имя свойства.</param>
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Присваивает по ссылке переменной field значение value.
        /// </summary>
        /// <typeparam name="T">Тип параметров field и value.</typeparam>
        /// <param name="field">Ссылка на переменную.</param>
        /// <param name="value">Значение, которое необходимо присвоить field.</param>
        /// <param name="property">Имя свойства.</param>
        /// <returns>Возвращает false, если значение field равно value, иначе true.</returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(property);
            return true;
        }

        #endregion

        #region Индекс выбранной функции

        private int _currentFunction;

        /// <summary>
        /// Хранит индекс выбранной функции.
        /// </summary>
        public int CurrentFunction
        {
            get => _currentFunction;
            set => Set(ref _currentFunction, value);
        }

        #endregion

        #region Коэффициент 'a'

        /// <summary>
        /// Хранит коэффициенты 'a' для каждой функции.
        /// Элемент с индексом 0 представляет коэффициент 'a' линейной функции, 1 - квадратичная, ... , 4 -> 5-ой степени.
        /// </summary>
        private int[] _coefficientsA = new int[5];

        /// <summary>
        /// Хранит коэффициент 'a' для выбранной функции
        /// </summary>
        public int A
        {
            get => _coefficientsA[CurrentFunction];
            set => Set(ref _coefficientsA[CurrentFunction], value);
        }

        #endregion

        #region Коэффициент 'b'

        /// <summary>
        /// Хранит коэффициенты 'b' для каждой функции.
        /// Элемент с индексом 0 представляет коэффициент 'b' линейной функции, 1 - квадратичной, ... , 4 -> 5-ой степени.
        /// </summary>
        private int[] _coefficientsB = new int[5];

        /// <summary>
        /// Хранит коэффициент 'b' для выбранной функции.
        /// </summary>
        public int B
        {
            get => _coefficientsB[CurrentFunction];
            set => Set(ref _coefficientsB[CurrentFunction], value);
        }

        #endregion
    }
}
