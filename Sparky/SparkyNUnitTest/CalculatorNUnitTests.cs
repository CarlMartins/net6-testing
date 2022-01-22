using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        int result = calculator.AddNumbers(10, 20);

        // Assert
        Assert.AreEqual(30, result);
    }

    [Test]
    [TestCase(11)]
    [TestCase(13)]
    public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool result = calculator.IsOddNumber(a);

        // Assert
        Assert.That(result, Is.EqualTo(true));
        Assert.IsTrue(result);
    }

    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(11, ExpectedResult = true)]
    public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
    {
        Calculator calculator = new();

        return calculator.IsOddNumber(a);
    }
    
    [Test]
    public void IsOddNumber_InputEvenNumber_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool result = calculator.IsOddNumber(2);

        // Assert
        Assert.That(result, Is.EqualTo(false));
        Assert.IsFalse(result);
    }
    
    [Test]
    [TestCase(5.4, 10.5)] //15.9
    [TestCase(5.43, 10.53)] //15.96
    [TestCase(5.49, 10.59)] //16.08
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        double result = calculator.AddNumbersDouble(a, b);

        // Assert
        Assert.AreEqual(15.9, result, .2);
    }

    [Test]
    public void OddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        Calculator calculator = new();
        List<int> expectedOddRange = new() {5, 7, 9};

        List<int> result = calculator.GetOddRange(5, 10);
        
        Assert.That(result, Is.EquivalentTo(expectedOddRange));
    }
}