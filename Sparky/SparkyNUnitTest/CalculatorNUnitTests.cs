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
}