using Castle.Core.Internal;
using Xunit;

namespace Sparky;

public class CostumerXUnitTests
{
    private Customer _customer;
    
    public CostumerXUnitTests()
    {
        _customer = new Customer();
    }
    
    [Fact]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        _customer.GreetAndCombineNames("Carlos", "Martins");
        

        Assert.Equal("Hello, Carlos Martins!", _customer.GreetMessage);
        Assert.Contains(",",_customer.GreetMessage);
        Assert.StartsWith("Hello",_customer.GreetMessage);
        Assert.EndsWith("!",_customer.GreetMessage);
        Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+",_customer.GreetMessage);
    }

    [Fact]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        var costumer = new Customer();
        
        Assert.Null(costumer.GreetMessage);
    }

    [Fact]
    public void DiscountCheck_DefaultCostumer_ReturnsDiscountInRange()
    {
        int result = _customer.Discount;
        
        Assert.InRange(result, 10, 25);
    }

    [Fact]
    public void GreetMessage_GreetedWithouLastName_ReturnsNotNull()
    {
        _customer.GreetAndCombineNames("Ben", "");
        
        Assert.NotNull(_customer.GreetMessage);
        Assert.False(string.IsNullOrEmpty(_customer.GreetMessage));
    }
    
    [Fact]
    public void GreetChecker_EmptyFirstName_ThrowsException()
    {
        var exceptionDetails = Assert
            .Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
        
        Assert.Equal("Empty first name", exceptionDetails.Message);
        Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
    }

    [Fact]
    public void CostumerType_CreateCostumerWithLessThan100Order_ReturnBasicCostumer()
    {
        _customer.OrderTotal = 10;
        var result = _customer.GetCustomerDetails();
        
        Assert.IsType<BasicCostumer>(result);
    }
}