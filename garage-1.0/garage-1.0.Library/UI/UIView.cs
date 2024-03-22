using SuperConsole;

namespace Garage_1_0.Library.UI;

public class UIView(string title, IEnumerable<IViewItem> viewItems) : IUIView
{
    private IO _io = IO.Instance;
    private UI _ui = UI.Instance;

    private string _title = title;
    private IEnumerable<IViewItem> _viewItems = viewItems;
    private int _activeIndex = 0;
    private bool _currentView;

    public UI ParentUI => _ui;
    public string Title => _title;
    public IEnumerable<IViewItem> ViewItems => _viewItems;
    public int ActiveIndex { get => _activeIndex; set => _activeIndex = value; }

    public void Enter()
    {
        _ui.ActiveView = this;
        do
        {
            WatchInput();
        } while (_ui.ActiveView == this);
    }

    private void Render()
    {
        Console.CursorVisible = false;
        _io.ClearAll();
        SetHeader();
        _io.WriteEncoded(ParentUI.Header ?? "");

        var viewItems = ViewItems.Select((item, index) => new { index, item });

        foreach (var item in viewItems)
        {
            string color = "green";
            if (item.index == ActiveIndex)
            {
                color = "red";
            }
            _io.Write(item.item.Title, foreground: color, newline: true);
        }
    }

    private void SetHeader()
    {
        ParentUI.Header = "[cyan]Garage 1.0" +
             Environment.NewLine +
             "---" +
             Environment.NewLine +
                Title +
             Environment.NewLine +
             "---[cyan]" +
             Environment.NewLine
             ;
    }

    protected virtual void WatchInput()
    {
        do
        {
            Render();
            var key = Console.ReadKey().Key;

            if (key is ConsoleKey.Enter)
            {
                // WIP! Ugly...
                var activeItem = ViewItems.ElementAt(ActiveIndex) as ViewActionItem;
                activeItem?.Action?.Invoke();
            }
            else if (key is ConsoleKey.DownArrow && ActiveIndex < ViewItems.Count() - 1)
            {
                ActiveIndex++;
            }
            else if (key is ConsoleKey.UpArrow && ActiveIndex > 0)
            {
                ActiveIndex--;
            }
        } while (true);
    }
}