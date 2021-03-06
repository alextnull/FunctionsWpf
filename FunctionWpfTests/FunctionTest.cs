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
        [DataRow(100, 50, 4, 25, 30, 2554)]
        [DataRow(2.45, 3.33, 5, 6.78, 30.28, 24.94)]
        [DataRow(2.45, 2.75, 5, 6.48, 30.28, 23.63)]
        [DataRow(1.25, 3.45, 4, double.MinValue, double.MinValue, double.NegativeInfinity)]
        [DataRow(double.MaxValue, double.MaxValue, 4, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.MinValue, double.MinValue, 2, double.MinValue, double.MinValue, double.PositiveInfinity)]
        public void Test_LinearFunctionCalculation_Validate(double a, double b, int c, double x, double y, double expected)
        {
            Function function = new Function(x, y);

            double functionResult = function.Calculate(a, b, c, Function.FunctionType.Linear);
            bool isExpectedFunctionResult = functionResult.CompareTo(expected) == 0
                            ? true
                            : false;

            Assert.IsTrue(isExpectedFunctionResult);
        }

        [DataTestMethod]
        [DataRow(0, 0, 10, 0, 0, 10)]
        [DataRow(1, 1, 20, 1, 1, 22)]
        [DataRow(-1, -1, 30, -1, -1, 30)]
        [DataRow(1.13, 1.99, 40, 70.15, 1.1, 5602.94)]
        [DataRow(-1.1, -1.1, 50, -1.1, -1.1, 49.88)]
        [DataRow(-90000.1, 25.13, 50, 92234, -1.1, -765640818751053.2)]
        [DataRow(1.25, 3.45, 40, double.MinValue, double.MinValue, double.NaN)]
        [DataRow(double.MaxValue, double.MaxValue, 40, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.MinValue, double.MinValue, 30, double.MinValue, double.MinValue, double.NaN)]
        public void Test_QuadraticFunctionCalculation_Validate(double a, double b, int c, double x, double y, double expected)
        {
            Function function = new Function(x, y);

            double functionResult = function.Calculate(a, b, c, Function.FunctionType.Quadratic);
            bool isExpectedFunctionResult = functionResult.CompareTo(expected) == 0
                            ? true
                            : false;

            Assert.IsTrue(isExpectedFunctionResult);
        }

        [DataTestMethod]
        [DataRow(0, 0, 100, 0, 0, 100)]
        [DataRow(1, 1, 200, 1, 1, 202)]
        [DataRow(-1, -1, 300, -1, -1, 300)]
        [DataRow(100, 50, 400, 2550, 13, 1658137508850)]
        [DataRow(1.13, 1.99, 300, 70.15, 1.1, 390389.40)]
        [DataRow(-1.1, -1.1, 100, -1.1, -1.1, 100.13)]
        [DataRow(-90000.1, 25.13, 200, 92234, -1.1, -7.061811527668671E+19)]
        [DataRow(1.25, 3.45, 400, double.MinValue, double.MinValue, double.NaN)]
        [DataRow(double.MaxValue, double.MaxValue, 400, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.MinValue, double.MinValue, 300, double.MinValue, double.MinValue, double.NaN)]
        public void Test_CubicFunctionCalculation_Validate(double a, double b, int c, double x, double y, double expected)
        {
            Function function = new Function(x, y);

            double functionResult = function.Calculate(a, b, c, Function.FunctionType.Cubic);
            bool isExpectedFunctionResult = functionResult.CompareTo(expected) == 0
                            ? true
                            : false;

            Assert.IsTrue(isExpectedFunctionResult);
        }

        [DataTestMethod]
        [DataRow(0, 0, 1000, 0, 0, 1000)]
        [DataRow(1, 1, 2000, 1, 1, 2002)]
        [DataRow(-1, -1, 3000, -1, -1, 3000)]
        [DataRow(70, 50, 5000, 16650, 13, 5.379662015437615E+18)]
        [DataRow(1.13, 1.99, 3000, 70.15, 1.1, 27367605.21)]
        [DataRow(-1.1, -1.1, 1000, -1.1, -1.1, 999.85)]
        [DataRow(-90000.1, 25.13, 2000, 92234, -1.1, -6.513391244429921E+24)]
        [DataRow(1.25, 3.45, 4000, double.MinValue, double.MinValue, double.NaN)]
        [DataRow(double.MaxValue, double.MaxValue, 400, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.MinValue, double.MinValue, 300, double.MinValue, double.MinValue, double.NaN)]
        public void Test_FourthDegreeFunctionCalculation_Validate(double a, double b, int c, double x, double y, double expected)
        {
            Function function = new Function(x, y);

            double functionResult = function.Calculate(a, b, c, Function.FunctionType.FourthDegree);
            bool isExpectedFunctionResult = functionResult.CompareTo(expected) == 0
                            ? true
                            : false;

            Assert.IsTrue(isExpectedFunctionResult);
        }
    }
}
