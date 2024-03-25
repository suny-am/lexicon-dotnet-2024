using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;
using Moq;

namespace garage_1._0.Tests;

public class MainMenuViewTests
{
    public MainMenuViewTests()
    {
    }

    [Fact]
    public void MainMenu_Enter_Sets_Itself_As_Active_View()
    {
        //ARRANGE
        Mock<IUI> ui = new();
        Mock<MainMenuView> mainMenuView = new();
       
        //ACT
        mainMenuView.Object.Enter();

        //ASSERT
        Assert.Equal(mainMenuView.Object.Title, UI.Instance.ActiveView!.Title);
    }

}