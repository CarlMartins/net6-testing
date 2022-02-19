using Sparky;
using Xunit;

namespace SparkyXUnitTest;

public class CalculatorXUnitTests
{
    [Fact]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        int result = calculator.AddNumbers(10, 20);

        // Assert
        Assert.Equal(30, result);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(13)]
    public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool result = calculator.IsOddNumber(a);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(10, false)]
    [InlineData(11, true)]
    public void IsOddNumber_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
    {
        Calculator calculator = new();
        
        var result = calculator.IsOddNumber(a);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void IsOddNumber_InputEvenNumber_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool result = calculator.IsOddNumber(2);

        // Assert
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(5.4, 10.5)] //15.9
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        // Arrange
        Calculator calculator = new();
    
        // Act
        double result = calculator.AddNumbersDouble(a, b);
    
        // Assert
        Assert.Equal(15.9, result);
    }
    
    [Fact]
    public void OddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        Calculator calculator = new();
        List<int> expectedOddRange = new() {5, 7, 9};
    
        List<int> result = calculator.GetOddRange(5, 10);
        
        Assert.Equal(expectedOddRange, result);
        Assert.Contains(7, result);
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Count);
        Assert.DoesNotContain(6, result);
        Assert.Equal(result.OrderBy(u => u), result);
    }
}