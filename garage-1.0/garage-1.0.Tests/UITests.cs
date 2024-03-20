using System.Linq.Expressions;
using Garage_1_0.Library.UI;

namespace garage_1._0.Tests;

public class UITests
{

    private Menu _menu;
    private IEnumerable<MenuOption<Expression>> _menuOptions;

    public UITests()
    {
        _menuOptions = [
            new(text: "test", action: Console.WriteLine)
        ];
        _menu = new(_menuOptions);
    }

    [Fact]
    public void Menu_Is_Created_With_Specified_Options()
    {
        // ASSERT
        Assert.Equal(_menuOptions, _menu.Options);
    }
}