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

    [Test]
    [TestCase(200,100)]
    [TestCase(200, 150)]
    public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x > 0))).Returns(true);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withdraw(withdraw);
        Assert.IsTrue(result);
    }
    
    [Test]
    [TestCase(200,300)]
    public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x > 0))).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x < 0))).Returns(false);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withdraw(withdraw);
        Assert.IsFalse(result);
    }
    
    [Test]
    public void BankLogDummy_LogMockString_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();
        string desiredOutput = "Hello";
        
        logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>()))
            .Returns((string str) => str);

        Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));
    }
    
    [Test]
    public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();
        string desiredOutput = "Hello";
        
        logMock.Setup(u => 
                u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput))
                    .Returns(true);

        string result = "";

        Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
        Assert.That(result, Is.EqualTo(desiredOutput));
    }
}