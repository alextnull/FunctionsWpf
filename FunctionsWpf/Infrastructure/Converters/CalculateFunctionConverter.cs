using FunctionsWpf.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FunctionsWpf.Infrastructure.Converters
{
    internal class CalculateFunctionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int a = int.Parse(values[0].ToString());
            int b = int.Parse(values[1].ToString());
            int c = int.Parse(values[2].ToString());
            int x = int.Parse(values[3].ToString());
            int y = int.Parse(values[4].ToString());
            int functionIndex = int.Parse(values[5].ToString());
            Function.FunctionType functionType = Function.GetFunctionTypeFromIndex(functionIndex);

            Function function = new Function(x, y);
            long functionValue = function.Calculate(a, b, c, functionType);
            return functionValue.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
