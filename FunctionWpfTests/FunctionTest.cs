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
