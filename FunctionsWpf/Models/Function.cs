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

        private double _x;
        
        /// <summary>
        /// Хранит значение аргумента 'x' функции
        /// </summary>
        public double X
        {
            get => _x;
            set => Set(ref _x, value);
        }

        #endregion

        #region Аргумент функции 'y'

        private double _y;

        /// <summary>
        /// Хранит значение аргумента 'x' функции
        /// </summary>
        public double Y
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
        public static FunctionType GetFunctionTypeFromIndex(int index)
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
        public double Calculate(double a, double b, int c, FunctionType functionType)
        {
            int powerNumber = (int)functionType + 1;
            double function = a * Math.Pow(X, powerNumber) + b * Math.Pow(Y, powerNumber - 1) + c;
            return function;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Инициализирует аргументы функции 'x' и 'y'
        /// </summary>
        /// <param name="x">Аргумент функции 'x'</param>
        /// <param name="y">Аргумент функции 'y'</param>
        public Function(double x = 0 , double y = 0)
        {
            X = x;
            Y = y;
        }

        #endregion
    }
}
