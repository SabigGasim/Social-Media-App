using FluentAssertions;
using SocialMediaApp.MVVM.ViewModels;

namespace SocialMediaApp.Tests.MVVM;
public class PropertyChangedNotifierTests
{
    private readonly IPropertyChangedNotifier _notifier;

    public PropertyChangedNotifierTests()
    {
        _notifier = new PropertyChangedNotifier();
    }

    [Fact]
    public void TrySetValue_ShouldReturn_False_WhenValueIsEqualToProperty()
    {
        //Arrange
        var prop = 1.5d;
        var propertyChangedCalls = 0;
        _notifier.PropertyChanged += (sender, args) => propertyChangedCalls++;

        //Act
        var result = _notifier.TrySetValue(ref prop, prop, "Prop");

        //Assert
        result.Should().BeFalse();
        propertyChangedCalls.Should().Be(0);
    }

    [Fact]
    public void TrySetValue_ShouldWork_And_ShouldReturn_True_WhenValueIsNotEqualToProperty()
    {
        //Arrange
        var prop = 1.5d;
        var value = 2.5d;
        var propertyChangedCalls = 0;
        _notifier.PropertyChanged += (sender, args) => propertyChangedCalls++;

        //Act
        var result = _notifier.TrySetValue(ref prop, value, "Prop");

        //Assert
        result.Should().BeTrue();
        value.Should().Be(value);
        propertyChangedCalls.Should().Be(1);
    }
}
