using FunctionsWpf.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionWpfTests
{
    [TestClass]
    public class FunctionTest
    {
        [DataTestMethod]
        [DataRow(0, 0, 1, 0, 0, 1)]
        [DataRow(1, 1, 2, 1, 1, 4)]
        [DataRow(-1, -1, 3, -1, -1, 3)]
        [DataRow(1.1, 1.1, 4, 1.1, 1.1, 6.31)]
        [DataRow(-1.1, -1.1, 5, -1.1, -1.1, 5.11)]
        [DataRow(100, 50, 440, 25, 30, 2990)]
        [DataRow(2.45, 3.33, 5, 6.78, 30.28, 24.94)]
        [DataRow(2.45, 2.75, 5, 6.48, 30.28, 23.63)]
        [DataRow(1.25, 3.45, 40, double.MinValue, double.MinValue, double.NegativeInfinity)]
        [DataRow(double.MaxValue, double.MaxValue, int.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.MinValue, double.MinValue, int.MinValue, double.MinValue, double.MinValue, double.PositiveInfinity)]
        public void Test_LinearFunctionCalculation_Validate(double a, double b, int c, double x, double y, double expected)
        {
            Function function = new Function(x, y);

            double functionResult = function.Calculate(a, b, c, Function.FunctionType.Linear);
            bool isExpectedFunctionResult = functionResult.CompareTo(expected) == 0
                            ? true
                            : false;

            Assert.IsTrue(isExpectedFunctionResult);
        }
    }
}
