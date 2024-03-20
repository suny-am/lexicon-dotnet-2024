namespace Garage_1_0.Library.UI.Menus;

public interface IMenuOption
{
    public string Title { get; set; }
    public Action Action { get; set;}
}