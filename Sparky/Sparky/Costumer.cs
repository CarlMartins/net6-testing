namespace Sparky;

public class Costumer
{
    public string GreetMessage { get; set; }
    public int Discount { get; set; } = 15;
    public int OrderTotal { get; set; }

    public string GreetAndCombineNames(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Empty first name");
        
        
        GreetMessage = $"Hello, {firstName} {lastName}!";
        Discount = 20;
        return GreetMessage;
    }

    public CostumerType GetCustomerDetails()
    {
        if (OrderTotal < 100) return new BasicCostumer();
        
        return new PlatinumCostumer();
    }
}

public class CostumerType { }
public class BasicCostumer : CostumerType { }
public class PlatinumCostumer : CostumerType { }