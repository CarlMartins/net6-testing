namespace Sparky;

public interface ICustomer
{
    string GreetMessage { get; set; }
    int Discount { get; set; } 
    int OrderTotal { get; set; }
    bool IsPlatinum { get; set; }
    string GreetAndCombineNames(string firstName, string lastName);
    CostumerType GetCustomerDetails();  
}

public class Customer : ICustomer
{
    public string GreetMessage { get; set; }
    public int Discount { get; set; }
    public int OrderTotal { get; set; }
    public bool IsPlatinum { get; set; }

    public Customer()
    {
        Discount = 15;
        IsPlatinum = false;
    }

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