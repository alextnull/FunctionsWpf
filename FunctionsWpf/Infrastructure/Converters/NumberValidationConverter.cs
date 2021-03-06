using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace FunctionsWpf.Infrastructure.Converters
{
    internal class NumberValidationConverter : IValueConverter
    {
        /// <summary>
        /// Хранит предыдущее значение числа. 
        /// </summary>
        private static double previousNumber = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// Преобразовывает некорректный ввод числа в корректный. В случае ошибки преобразования возвращает предыдущее число.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Возвращает корректное число</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string numberString = value.ToString();
                numberString = Regex.Replace(numberString, "[^-\\.0-9]", string.Empty);

                if (numberString.Length == 0)
                {
                    previousNumber = 0;
                    return 0;
                }

                if (numberString[0].Equals('-'))
                {
                    numberString = "-" + numberString.Replace("-", "");
                }

                double number = System.Convert.ToDouble(numberString, CultureInfo.InvariantCulture);
                previousNumber = number;

                if (double.IsPositiveInfinity(number))
                {
                    return double.MaxValue;
                }
                else if (double.IsNegativeInfinity(number))
                {
                    return double.MinValue;
                }
                else
                {
                    return number;
                }
            }
            catch
            {
                return previousNumber;
            }

        }

    }
}
