using Moq;
using Runner;
using Shared;

namespace Tests;

public class DayFactoryTests
{
    [Test]
    public async Task TestFactoryAsync()
    {
        Mock<IAdventClient> _adventClientMock = new();
        _adventClientMock.Setup(x => x.GetInputAsync(It.IsAny<int>()))
                        .ReturnsAsync("3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3");

        var result = await DayFactory.GetAnswerAsync(2024, 1, Part.first, _adventClientMock.Object);
        Assert.That(result, Is.EqualTo("11"));
    }

}
