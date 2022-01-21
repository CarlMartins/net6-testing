using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CostumerNUnitTests
{
    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        var costumer = new Costumer();

        costumer.GreetAndCombineNames("Carlos", "Martins");
        
        Assert.AreEqual("Hello, Carlos Martins!", costumer.GreetMessage);
        Assert.That(costumer.GreetMessage, Is.EqualTo("Hello, Carlos Martins!"));
        Assert.That(costumer.GreetMessage, Does.Contain(","));
        Assert.That(costumer.GreetMessage, Does.StartWith("Hello"));
        Assert.That(costumer.GreetMessage, Does.EndWith("!"));
        Assert.That(costumer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        var costumer = new Costumer();
        
        Assert.IsNull(costumer.GreetMessage);
    }
}