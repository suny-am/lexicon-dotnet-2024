namespace garage_1._0.Tests;

using Garage_1_0.Library.UI;
using Garage_1_0.Library.UI.Views;
using Garage_1_0.Tests.Mocks;
using Moq;

public class UITests
{
    private readonly IUI _ui;

    public UITests()
    {
        _ui = new MockUI
        {
            Title = "Test Title"
        };
    }

    [Fact]
    public void UI_Title_Is_Set_Correctly()
    {
        //ASSERT
        Assert.Equal("Test Title", _ui.Title);
    }

    [Fact]
    public void UI_Is_Populated_With_Views()
    {
        // ARRANGE
        IEnumerable<IUIView> viewList =
        [
            new Mock<IUIView>().Object,
            new Mock<IUIView>().Object,
            new Mock<IUIView>().Object,
        ];

        // ACT
        _ui.Views = viewList;

        // ASSERT
        Assert.Equal(viewList.Count(), _ui.Views.Count());
    }

    [Fact]
    public void UI_Loads_Garages_Creates_File_Writer_Instance()
    {
        //ARRANGE

        //ACT
        _ui.LoadGarages();


        //ASSERT

    }
}