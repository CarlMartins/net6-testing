namespace Sparky;

public class Costumer
{
    public string GreetMessage { get; set; }
    
    public string GreetAndCombineNames(string firstName, string lastName)
    {
        GreetMessage = $"Hello, {firstName} {lastName}!";
        return GreetMessage;
    }
}