using Moq;
using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{
    private BankAccount _bankAccount;
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void BankDeposit_Add100_ShouldReturnTrue()
    {
        var logMock = new Mock<ILogBook>();
        
        _bankAccount = new (logMock.Object);
        var result = _bankAccount.Deposit(100);
        
        Assert.IsTrue(result);
        Assert.That(_bankAccount.Balance, Is.EqualTo(100));
    }
}