using FluentAssertions;
using NSubstitute;
using SocialMediaApp.Services;

namespace SocialMediaApp.Tests.Services;
public class DateTimeHumanizerTests
{
    private readonly IDateTimeHumanizerService _humanizer;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IDateTimeProvider _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();

            
    public DateTimeHumanizerTests()
    {
        _humanizer = new DateTimeHumanizerService();
        _dateTimeProvider = new DateTimeProvider();
    }

    [Fact]
    public void DateTimeHumanizerService_Humanize_ShouldReturn_1hour()
    {
        //Arrange

        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddHours(-1).AddSeconds(-10));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 hour");
    }

    [Fact]
    public void DateTimeHumanizerService_Humanize_ShouldReturn_30Seconds()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddSeconds(-30));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("30 seconds");
    }

    [Fact]
    public void DateTimeHumanizerService_Humanize_ShouldReturn_Now()
    {
        //Arrange

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProvider.Now);

        //Assert
        humanizedDatetime.Should().Be("Now");
    }

    [Fact]
    public void DateTimeHumanizerService_Humanize_ShouldReturn_1year()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddYears(-1).AddDays(-2));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 year");
    }

    [Fact]
    public void DateTimeHumanizerService_Humanize_ShouldReturn_20years()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddYears(-20).AddSeconds(-10));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("20 years");
    }

    [Fact]
    public void DateTimeOffsetHumanizerService_Humanize_ShouldReturn_1hour()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTime.Now.AddHours(-1).AddSeconds(-10));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 hour");
    }

    [Fact]
    public void DateTimeOffsetHumanizerService_Humanize_ShouldReturn_30Seconds()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTime.Now.AddSeconds(-30));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("30 seconds");
    }

    [Fact]
    public void DateTimeOffsetHumanizerService_Humanize_ShouldReturn_Now()
    {
        //Arrange

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProvider.Now);

        //Assert
        humanizedDatetime.Should().Be("Now");
    }

    [Fact]
    public void DateTimeOffsetHumanizerService_Humanize_ShouldReturn_1year()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTime.Now.AddYears(-1).AddDays(-2));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 year");
    }

    [Fact]
    public void DateTimeOffsetHumanizerService_Humanize_ShouldReturn_20years()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTime.Now.AddYears(-20).AddSeconds(-10));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("20 years");
    }
}
