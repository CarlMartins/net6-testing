namespace Sparky;

public interface ILogBook
{
    void Message(string message);
    bool LogToDb(string message);
    bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
}

public class LogBook : ILogBook
{
    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public bool LogToDb(string message)
    {
        Console.WriteLine(message);
        return true;
    }

    public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
    {
        if (balanceAfterWithdrawal >= 0)
        {
            Console.WriteLine("Success");
            return true;
        }
        
        Console.WriteLine("Failure");
        return false;
    }
}