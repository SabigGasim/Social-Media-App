using FluentAssertions;
using SocialMediaApp.MVVM.ViewModels.Converters;
using SocialMediaApp.Services;

namespace SocialMediaApp.Tests.Converters;
public class DateTimeToStringConverterTests
{
	private readonly IValueConverter _dateTimeToStringConverter;

	public DateTimeToStringConverterTests()
	{
		_dateTimeToStringConverter = new DateTimeToStringConverter(new DateTimeHumanizerService());
    }

	[Fact]
	public void Convert_ShouldWork()
	{
		//Arrange

		//Act
		var result = (string?)_dateTimeToStringConverter.Convert(DateTime.Now, null, null, null);

		//Assert
		result.Should().NotBeNullOrWhiteSpace();
	}

	[Fact]
	public void Convert_ShouldReturnNull_WhenValueIsNull()
	{
        //Arrange

        //Act
        var result = (string?)_dateTimeToStringConverter.Convert(null, null, null, null);

        //Assert
        result.Should().BeNullOrWhiteSpace();
    }

    [Fact]
    public void Convert_ShouldReturnNull_WhenValueIsNotOfTypeDateTime()
    {
        //Arrange

        //Act
        var result = (string?)_dateTimeToStringConverter.Convert(90, null, null, null);

        //Assert
        result.Should().BeNullOrWhiteSpace();
    }
}
