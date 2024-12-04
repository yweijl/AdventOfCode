using Moq;
using Shared;
using Year2024.Days;

namespace Year2024.Tests.Days.Tests;

public class Day2Tests
{
    private Mock<IAdventClient> _adventClientMock = new();

    [SetUp]
    public void Setup()
    {
        _adventClientMock.Setup(x => x.GetInputAsync(It.IsAny<int>()))
            .ReturnsAsync("7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9");
    }
    
    [Test]
    public async Task Part1Async()
    {
        var day = new Day2(_adventClientMock.Object);
        var result = await day.ExecuteFirstAsync();
        Assert.That(result, Is.EqualTo("2"));
    }

    [Test]
    public async Task Part2Async()
    {
        var day = new Day2(_adventClientMock.Object);
        var result = await day.ExecuteSecondAsync();
        Assert.That(result, Is.EqualTo("4"));
    }
}

