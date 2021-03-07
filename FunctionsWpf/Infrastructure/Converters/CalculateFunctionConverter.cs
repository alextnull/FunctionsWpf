using FunctionsWpf.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FunctionsWpf.Infrastructure.Converters
{
    /// <summary>
    /// Конвертер для расчёта значения функции
    /// </summary>
    internal class CalculateFunctionConverter : IMultiValueConverter
    {
        #region Методы

        /// <summary>
        /// Рассчитывает значение функции и привязывает его к необходимому объекту.
        /// </summary>
        /// <returns>Возвращает значение функции в строковом виде.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double a = double.Parse(values[0].ToString());
                double b = double.Parse(values[1].ToString());
                int c = int.Parse(values[2].ToString());
                double x = double.Parse(values[3].ToString());
                double y = double.Parse(values[4].ToString());
                int functionIndex = int.Parse(values[5].ToString());
                Function.FunctionType functionType = Function.GetFunctionTypeFromIndex(functionIndex);

                var function = new Function(x, y);
                double functionValue = function.Calculate(a, b, c, functionType);
                return functionValue.ToString("0.00", CultureInfo.InvariantCulture);
            }
            catch 
            {
                return double.NaN;
            }

            
        }

        /// <summary>
        /// Не релизовано.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
