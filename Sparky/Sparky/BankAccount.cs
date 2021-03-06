namespace Sparky;

public class BankAccount
{
    private readonly ILogBook _logBook;
    public int Balance { get; set; }

    public BankAccount(ILogBook logBook)
    {
        _logBook = logBook;
        Balance = 0;
    }

    public bool Deposit(int amount)
    {
        _logBook.Message("Deposit Invoked");
        _logBook.Message("Test");
        _logBook.LogSeverity = 101;
        var temp = _logBook.LogSeverity;
        Balance += amount;
        return true;
    }
    
    public bool Withdraw(int amount)
    {
        if (amount <= Balance)
        {
            _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
            Balance -= amount;
            return _logBook.LogBalanceAfterWithdrawal(Balance); 
        }
        return _logBook.LogBalanceAfterWithdrawal(Balance-amount); 
    }
}