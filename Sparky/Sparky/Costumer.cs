namespace Sparky;

public class Costumer
{
    public string GreetMessage { get; set; }
    public int Discount { get; set; } = 15;
    
    public string GreetAndCombineNames(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Empty first name");
        
        
        GreetMessage = $"Hello, {firstName} {lastName}!";
        Discount = 20;
        return GreetMessage;
    }
}