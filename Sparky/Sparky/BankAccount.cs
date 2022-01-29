namespace Sparky;

public class BankAccount
{
    public int Balance { get; set; }

    public BankAccount()
    {
        
    }

    public bool Deposit(int amount)
    {
        Balance += amount;
        return true;
    }
    
    public bool Withdraw(int amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}