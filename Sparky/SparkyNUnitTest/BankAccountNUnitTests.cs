using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class BankAccountNUnitTests
{
    private BankAccount _bankAccount;
    
    [SetUp]
    public void Setup()
    {
        _bankAccount = new (new LogFakker());
    }

    [Test]
    public void BankDeposit_Add100_ShouldReturnTrue()
    {
        var result = _bankAccount.Deposit(100);
        
        Assert.IsTrue(result);
        Assert.That(_bankAccount.Balance, Is.EqualTo(100));
    }
}