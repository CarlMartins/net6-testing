using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CostumerNUnitTests
{
    private Costumer _costumer;
    
    [SetUp]
    public void Setup()
    {
        _costumer = new Costumer();
    }
    
    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        _costumer.GreetAndCombineNames("Carlos", "Martins");
        
        Assert.AreEqual("Hello, Carlos Martins!", _costumer.GreetMessage);
        Assert.That(_costumer.GreetMessage, Is.EqualTo("Hello, Carlos Martins!"));
        Assert.That(_costumer.GreetMessage, Does.Contain(","));
        Assert.That(_costumer.GreetMessage, Does.StartWith("Hello"));
        Assert.That(_costumer.GreetMessage, Does.EndWith("!"));
        Assert.That(_costumer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        var costumer = new Costumer();
        
        Assert.IsNull(costumer.GreetMessage);
    }
}