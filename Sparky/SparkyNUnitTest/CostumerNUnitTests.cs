using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CostumerNUnitTests
{
    private Customer _customer;
    
    [SetUp]
    public void Setup()
    {
        _customer = new Customer();
    }
    
    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        _customer.GreetAndCombineNames("Carlos", "Martins");
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual("Hello, Carlos Martins!", _customer.GreetMessage);
            Assert.That(_customer.GreetMessage, Is.EqualTo("Hello, Carlos Martins!"));
            Assert.That(_customer.GreetMessage, Does.Contain(","));
            Assert.That(_customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(_customer.GreetMessage, Does.EndWith("!"));
            Assert.That(_customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        });
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        var costumer = new Customer();
        
        Assert.IsNull(costumer.GreetMessage);
    }

    [Test]
    public void DiscountCheck_DefaultCostumer_ReturnsDiscountInRange()
    {
        int result = _customer.Discount;
        
        Assert.That(result, Is.InRange(10, 25));
    }

    [Test]
    public void GreetMessage_GreetedWithouLastName_ReturnsNotNull()
    {
        _customer.GreetAndCombineNames("Ben", "");
        
        Assert.IsNotNull(_customer.GreetMessage);
        Assert.IsFalse(string.IsNullOrEmpty(_customer.GreetMessage));
    }
    
    [Test]
    public void GreetChecker_EmptyFirstName_ThrowsException()
    {
        var exceptionDetails = Assert
            .Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
        
        Assert.AreEqual("Empty first name", exceptionDetails.Message);
        Assert.That(() => _customer
            .GreetAndCombineNames("", "Spark"), Throws.ArgumentException.With.Message.EqualTo("Empty first name"));

        Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
        Assert.That(() => _customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException);
    }

    [Test]
    public void CostumerType_CreateCostumerWithLessThan100Order_ReturnBasicCostumer()
    {
        _customer.OrderTotal = 10;
        var result = _customer.GetCustomerDetails();
        
        Assert.That(result, Is.TypeOf<BasicCostumer>());
    }
}