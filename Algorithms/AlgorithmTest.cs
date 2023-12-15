using System;
using System.Numerics;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {

        [Theory]
        [InlineData(0, "1")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "6")]
        [InlineData(4, "24")]
        [InlineData(5, "120")]
        [InlineData(10, "3628800")]
        [InlineData(20, "2432902008176640000")]
        [InlineData(30, "265252859812191058636308480000000")]
        public void CanGetFactorial(int param, string expectedResult)
        {
            //Arrange
            BigInteger expected = BigInteger.Parse(expectedResult);

            //Act
            BigInteger actual = Algorithms.GetFactorial(param);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFactorial_WithNegativeNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(-1));
        }

        [Theory]
        [InlineData(new[] { "a", "b", "c" }, "a, b and c")]
        [InlineData(new[] { "j", "k", "l", "m", "n", "o" }, "j, k, l, m, n and o")]
        [InlineData(new[] { "x", "y" }, "x and y")]
        [InlineData(new[] { "z" }, "z")]
        [InlineData(null, "")]
        [InlineData(new string[] { }, "")]
        public void CanFormatSeparatorsAsArray(string[] param, string expectedResult) => Assert.Equal(expectedResult, Algorithms.FormatSeparators(param));

        [Fact]
        public void CanFormatSeparatorsAsSeparteParams()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }
    }
}