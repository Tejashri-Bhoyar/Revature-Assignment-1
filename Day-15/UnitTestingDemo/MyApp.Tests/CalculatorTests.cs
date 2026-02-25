using Xunit;
using MyApp;

namespace MyApp.Tests
{
    public class CalculatorTests
    {
        // ---------- ADD ----------
        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(5, 5, 10)]
        [InlineData(2, 3, 5)]
        public void Add_TwoNumbers_GivesCorrectResult(int x, int y, int expected)
        {
            var calc = new Calculator();
            var actual = calc.Add(x, y);
            Assert.Equal(expected, actual);
        }

        // ---------- SUBTRACT ----------
        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(5, 3, 2)]
        public void Subtract_TwoNumbers_GivesCorrectResult(int x, int y, int expected)
        {
            var calc = new Calculator();
            var actual = calc.Subtract(x, y);
            Assert.Equal(expected, actual);
        }

        // ---------- MULTIPLY ----------
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(5, 4, 20)]
        [InlineData(10, 0, 0)]
        public void Multiply_TwoNumbers_GivesCorrectResult(int x, int y, int expected)
        {
            var calc = new Calculator();
            var actual = calc.Multiply(x, y);
            Assert.Equal(expected, actual);
        }

        // ---------- DIVIDE ----------
        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(20, 4, 5)]
        public void Divide_TwoNumbers_GivesCorrectResult(int x, int y, int expected)
        {
            var calc = new Calculator();
            var actual = calc.Divide(x, y);
            Assert.Equal(expected, actual);
        }

        // ---------- DIVIDE BY ZERO ----------
        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            var calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }
    }
}