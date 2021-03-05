using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunctionsWpf.Models
{
    public class Function : INotifyPropertyChanged
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

        #region Аргумент функции 'x'

        private int _x;
        
        /// <summary>
        /// Хранит значение аргумента 'x' функции
        /// </summary>
        public int X
        {
            get => _x;
            set => Set(ref _x, value);
        }

        #endregion

        #region Аргумент функции 'y'

        private int _y;

        /// <summary>
        /// Хранит значение аргумента 'x' функции
        /// </summary>
        public int Y
        {
            get => _y;
            set => Set(ref _y, value);
        }

        #endregion

        #region Перечисление для указания типа функции

        /// <summary>
        /// Используется для указания типа функции
        /// </summary>
        public enum FunctionType { Linear, Quadratic, Cubic, FourthDegree, FiveDegree }

        /// <summary>
        /// Возвращает тип функции с помощь индекса
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FunctionType GetFunctionTypeFromIndex(int index)
        {
            if (index < 0 || index > 4)
                throw new ArgumentException();
            return (FunctionType)index;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Вычисляет значение функции в зависимости от параметра functionType
        /// </summary>
        /// <param name="a">Коэффициент функции 'a'</param>
        /// <param name="b">Коэффициент функции 'b'</param>
        /// <param name="c">Коэффициент функции 'c'</param>
        /// <param name="functionType">Тип функции</param>
        /// <returns>Возвращает значение функции</returns>
        public long Calculate(int a, int b, int c, FunctionType functionType)
        {
            int powerNumber = (int)functionType + 1;
            long function = a * (long)Math.Pow(X, powerNumber) + b * (long)Math.Pow(Y, powerNumber - 1) + c;
            return function;
        }

        #endregion
    }
}
