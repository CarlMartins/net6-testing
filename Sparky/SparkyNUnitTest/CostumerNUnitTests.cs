using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class CostumerNUnitTests
{
    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        var costumer = new Costumer();

        string fullName = costumer.GreetAndCombineNames("Carlos", "Martins");
        
        Assert.AreEqual("Hello, Carlos Martins!", fullName);
        Assert.That(fullName, Is.EqualTo("Hello, Carlos Martins!"));
        Assert.That(fullName, Does.Contain(","));
        Assert.That(fullName, Does.StartWith("Hello"));
        Assert.That(fullName, Does.EndWith("!"));
        Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }
}