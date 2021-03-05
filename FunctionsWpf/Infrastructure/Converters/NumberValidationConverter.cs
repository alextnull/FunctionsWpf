using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace FunctionsWpf.Infrastructure.Converters
{
    internal class NumberValidationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// Преобразовывает некорректный ввод числа в корректный.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string numberString = value.ToString();
                numberString = Regex.Replace(numberString, "[^-0-9]", string.Empty);

                if (numberString.Length == 0)
                {
                    return 0;
                }

                if (numberString[0].Equals('-'))
                {
                    numberString = "-" + numberString.Replace("-", "");
                }

                long number = System.Convert.ToInt64(numberString);
                if (number > int.MaxValue)
                {
                    return int.MaxValue;
                }
                else if (number < int.MinValue)
                {
                    return int.MinValue;
                }
                else
                {
                    return System.Convert.ToInt32(numberString);
                }
            }
            catch
            {
                return 0;
            }

        }
    }
}
