using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace FunctionsWpf.Infrastructure.Converters
{
    /// <summary>
    /// Конвертер для корректировки пользовательского ввода чисел
    /// </summary>
    internal class NumberValidationConverter : IValueConverter
    {
        #region Поля

        /// <summary>
        /// Хранит предыдущее значение числа. 
        /// </summary>
        private static double previousNumber = 0;

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает переданное значение без изменений.
        /// </summary>
        /// <returns>Возвращает value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// Преобразовывает некорректный ввод числа в корректный. В случае ошибки преобразования возвращает предыдущее число.
        /// </summary>
        /// <returns>Возвращает корректное число типа double.</returns>
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

                int numberLength = numberString.Length;
                string previousNumberString = previousNumber.ToString();
                int previousNumberLength = previousNumberString.Length;

                int numberLastDigit = int.Parse(numberString[numberLength - 1].ToString());
                int previousNumberLastDigit = int.Parse(previousNumberString[previousNumberLength - 1].ToString());

                if ((numberLength > previousNumberLength) && (numberLastDigit != previousNumberLastDigit))
                {
                    numberString = numberString.Substring(0, numberLength - 1);  
                }
                else if ((numberLength > previousNumberLength) && (numberLastDigit == previousNumberLastDigit) && (numberLastDigit > 4))
                {
                    numberString = numberString.Substring(0, numberLength - 1);
                }

                if (numberString[0] == '-')
                {
                    numberString = $"-{numberString.Replace("-", "")}";
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

                return number;
            }
            catch
            {
                return previousNumber;
            }
        }

        #endregion
    }
}
