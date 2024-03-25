namespace garage_1._0.Tests;

using Garage_1_0.Library.Models;
using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;
using Microsoft.Extensions.Configuration;
using Moq;

public class UITests
{
    private readonly IConfiguration _configuration = new ConfigurationBuilder().Build();
    private readonly Mock<IUI> _ui;
    private readonly IEnumerable<IGarage<IParkingSpot>> _garageList =
    [
       new Garage<IParkingSpot>("1",5),
       new Garage<IParkingSpot>("2",5),
       new Garage<IParkingSpot>("3",5),
    ];
    private IEnumerable<IUIView> _viewList =
        [
            new Mock<IUIView>().Object,
            new Mock<IUIView>().Object,
            new Mock<IUIView>().Object,
        ];

    public UITests()
    {
        _ui = new Mock<IUI>();
    }

    [Fact]
    public void UI_Title_Is_Set_Correctly()
    {
        //ARRANGE
        _ui.Setup(_ui => _ui.Title).Returns("Mock Title");

        //ASSERT
        Assert.Equal("Mock Title", _ui.Object.Title);
    }

    [Fact]
    public void UI_Is_Populated_With_Views()
    {
        // ARRANGE

        _ui.Setup(_ui => _ui.Views).Returns(_viewList);

        // ACT

        // ASSERT
        Assert.Equal(_viewList, _ui.Object.Views!);
    }

    [Fact]
    public void UI_Loads_Garages_Correctly_When_Configuration_Is_Set()
    {
        //ARRANGE
        _ui.Setup(_ui => _ui.GarageList).Returns(_garageList);
        _ui.Object.Configuration = _configuration;
        //ACT

        _ui.Object.LoadGarages();

        //ASSERT
        Assert.Equal(_garageList, _ui.Object.GarageList!);
    }

}