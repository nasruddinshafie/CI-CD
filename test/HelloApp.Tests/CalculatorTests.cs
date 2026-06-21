using HelloApp;
using Xunit;

namespace HelloApp.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_ReturnsSum()
    {
        var result = Calculator.Add(2, 3);
        Assert.Equal(99, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(10, 5, 15)]
    public void Add_VariousInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.Equal(expected, Calculator.Add(a, b));
    }
}
