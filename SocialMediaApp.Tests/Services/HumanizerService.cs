using FluentAssertions;
using NSubstitute;
using SocialMediaApp.Services;

namespace SocialMediaApp.Tests.Services;
public class HumanizerService
{
    private readonly IHumanizerService _humanizer;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IDateTimeProvider _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();

            
    public HumanizerService()
    {
        _humanizer = new SocialMediaApp.Services.HumanizerService();
        _dateTimeProvider = new DateTimeProvider();
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_1K()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(1_000);

        //Assert
        result.Should().Be("1K");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_1_52K()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(1_520);

        //Assert
        result.Should().Be("1.52K");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_1B()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(1_000_000_000);

        //Assert
        result.Should().Be("1B");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_700B()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(700_000_000_000);

        //Assert
        result.Should().Be("700B");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_1M()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(1_000_200);

        //Assert
        result.Should().Be("1M");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldMatchFormat_69()
    {
        //Arrange

        //Act
        var result = _humanizer.Humanize(69);

        //Assert
        result.Should().Be("69");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldReturn_1hour()
    {
        //Arrange

        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddHours(-1).AddSeconds(-10));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 hour");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldReturn_30Seconds()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddSeconds(-30));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("30 seconds");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldReturn_Now()
    {
        //Arrange

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProvider.Now);

        //Assert
        humanizedDatetime.Should().Be("Now");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldReturn_1year()
    {
        //Arrange
        _dateTimeProviderMock.Now.Returns(DateTimeOffset.Now.AddYears(-1).AddDays(-2));

        //Act
        var humanizedDatetime = _humanizer.Humanize(_dateTimeProviderMock.Now);

        //Assert
        humanizedDatetime.Should().Be("1 year");
    }

    [Fact]
    public void HumanizerService_Humanize_ShouldReturn_20years()
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
