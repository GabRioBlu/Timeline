using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Timeline.Controls;

namespace Timeline.Views;

public partial class EditPanel : UserControl
{
    private TimelineItem editedItem;

    public EditPanel()
    {
        editedItem = new TimelineItem();

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public TimelineItem EditedItem
    {
        get { return editedItem; }
        set { editedItem = value; }
    }
}