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
        
        Assert.That(fullName, Is.EqualTo("Hello, Carlos Martins!"));
    }
}