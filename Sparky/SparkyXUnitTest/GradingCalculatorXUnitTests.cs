using Sparky;
using Xunit;

namespace SparkyXUnitTest;

public class GradingCalculatorXUnitTests
{
    private GradingCalculator _calculator;
    
    public GradingCalculatorXUnitTests()
    {
        _calculator = new GradingCalculator();
    }

    [Fact]
    public void GetGrade_Score95Attendance90_ShouldReturnA()
    {
        _calculator.Score = 95;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.Equal("A", result);
        Assert.IsType<string>(result);
    }
    
    [Fact]
    public void GetGrade_Score85Attendance90_ShouldReturnB()
    {
        _calculator.Score = 85;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.Equal("B", result);
        Assert.IsType<string>(result);
    }
    
    [Fact]
    public void GetGrade_Score65Attendance90_ShouldReturnC()
    {
        _calculator.Score = 65;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.Equal("C", result);
        Assert.IsType<string>(result);
    }
    
    [Fact]
    public void GetGrade_Score95Attendance65_ShouldReturnB()
    {
        _calculator.Score = 95;
        _calculator.AttendancePercentage = 65;

        var result = _calculator.GetGrade();
        
        Assert.Equal("B", result);
        Assert.IsType<string>(result);
    }
    
    [Theory]
    [InlineData(95, 55)]
    [InlineData(65, 55)]
    [InlineData(50, 90)]
    public void GetGrade_FalingScenarios_ShouldReturnF(int score, int attendancePercentage)
    {
        _calculator.Score = score;
        _calculator.AttendancePercentage = attendancePercentage;

        var result = _calculator.GetGrade();
        
        Assert.Equal("F", result);
        Assert.IsType<string>(result);
    }
    
    [Theory]
    [InlineData(95, 90,"A")]
    [InlineData(85, 90, "B")]
    [InlineData(65, 90, "C")]
    [InlineData(95, 65, "B")]
    [InlineData(95, 55, "F")]
    [InlineData(65, 55, "F")]
    [InlineData(50, 90, "F")]
    public void GetGrade_AllGradeLogicalScenarios_GradeOutput(int score, int attendancePercentage, string expectedResult)
    {
        _calculator.Score = score;
        _calculator.AttendancePercentage = attendancePercentage;

       var result = _calculator.GetGrade();
       
       Assert.Equal(expectedResult, result);
    }
}