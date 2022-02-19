using Sparky;
using Xunit;

namespace SparkyXUnitTest;

public class FiboTests
{
    private Fibo _fibo;
    
    public FiboTests()
    {
        _fibo = new Fibo();
    }

    [Fact]
    public void GetFiboSeries_WithRangeOf1_ShouldBeRight()
    {
        List<int> expectedRange = new() {0};
        _fibo.Range = 1;

        var result = _fibo.GetFiboSeries();
        
        Assert.NotEmpty(result);
        Assert.Equal(expectedRange.OrderBy(u => u), result);
        Assert.True(result.SequenceEqual(expectedRange));
    }
    
    [Fact]
    public void GetFiboSeries_WithRangeOf6_ShouldBeRight()
    {
        List<int> expectedRange = new() {0, 1, 1, 2, 3, 5};  
        _fibo.Range = 6;

        var result = _fibo.GetFiboSeries();
        
        Assert.Contains(3, result);
        Assert.Equal(6,result.Count);
        Assert.DoesNotContain(4, result);
        Assert.Equal(expectedRange, result);
    }
}