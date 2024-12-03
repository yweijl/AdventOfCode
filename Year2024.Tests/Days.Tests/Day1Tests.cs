using Moq;
using Shared;
using Year2024.Days;

namespace Year2024.Tests.Days.Tests;

public class Day1Tests
{
    private Mock<IAdventClient> _adventClientMock = new();
    
    [Test]
    public async Task Part1Async()
    {
        _adventClientMock.Setup(x => x.GetInputAsync(It.IsAny<int>()))
            .ReturnsAsync("3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3");
        var day = new Day1(_adventClientMock.Object);
        var result = await day.ExecuteFirstAsync();
        Assert.That(result, Is.EqualTo("11"));
    }

    [Test]
    public async Task Part2Async()
    {
        _adventClientMock.Setup(x => x.GetInputAsync(It.IsAny<int>()))
            .ReturnsAsync("3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3");
        var day = new Day1(_adventClientMock.Object);
        var result = await day.ExecuteSecondAsync();
        Assert.That(result, Is.EqualTo("31"));
    }
}

