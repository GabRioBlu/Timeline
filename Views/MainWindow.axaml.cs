using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Timeline.Controls;

namespace Timeline.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddEvent(object sender, RoutedEventArgs e)
    {
        this.FindControl<TimelineContainer>("Timeline").Children.Add(new TimelineItem() { Title = "Lettuce" });
    }
}