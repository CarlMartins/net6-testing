using NUnit.Framework;

namespace Sparky;

[TestFixture]
public class GradingCalculatorNUnitTests
{
    private GradingCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new GradingCalculator();
    }

    [Test]
    public void GetGrade_Score95Attendance90_ShouldReturnA()
    {
        _calculator.Score = 95;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.That(result, Is.EqualTo("A"));
        Assert.AreEqual("A", result);
        Assert.That(result, Is.TypeOf<string>());
    }
    
    [Test]
    public void GetGrade_Score85Attendance90_ShouldReturnB()
    {
        _calculator.Score = 85;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.That(result, Is.EqualTo("B"));
        Assert.AreEqual("B", result);
        Assert.That(result, Is.TypeOf<string>());
    }
    
    [Test]
    public void GetGrade_Score65Attendance90_ShouldReturnC()
    {
        _calculator.Score = 65;
        _calculator.AttendancePercentage = 90;

        var result = _calculator.GetGrade();
        
        Assert.That(result, Is.EqualTo("C"));
        Assert.AreEqual("C", result);
        Assert.That(result, Is.TypeOf<string>());
    }
    
    [Test]
    public void GetGrade_Score95Attendance65_ShouldReturnB()
    {
        _calculator.Score = 95;
        _calculator.AttendancePercentage = 65;

        var result = _calculator.GetGrade();
        
        Assert.That(result, Is.EqualTo("B"));
        Assert.AreEqual("B", result);
        Assert.That(result, Is.TypeOf<string>());
    }
    
    [Test]
    [TestCase(95, 55)]
    [TestCase(65, 55)]
    [TestCase(50, 90)]
    public void GetGrade_FalingScenarios_ShouldReturnF(int score, int attendancePercentage)
    {
        _calculator.Score = score;
        _calculator.AttendancePercentage = attendancePercentage;

        var result = _calculator.GetGrade();
        
        Assert.That(result, Is.EqualTo("F"));
        Assert.AreEqual("F", result);
        Assert.That(result, Is.TypeOf<string>());
    }
    
    [Test]
    [TestCase(95, 90, ExpectedResult = "A")]
    [TestCase(85, 90, ExpectedResult = "B")]
    [TestCase(65, 90, ExpectedResult = "C")]
    [TestCase(95, 65, ExpectedResult = "B")]
    [TestCase(95, 55, ExpectedResult = "F")]
    [TestCase(65, 55, ExpectedResult = "F")]
    [TestCase(50, 90, ExpectedResult = "F")]
    public string GetGrade_AllGradeLogicalScenarios_GradeOutput(int score, int attendancePercentage)
    {
        _calculator.Score = score;
        _calculator.AttendancePercentage = attendancePercentage;

       return _calculator.GetGrade();
    }
}