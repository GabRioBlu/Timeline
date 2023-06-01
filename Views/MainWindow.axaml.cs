using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Timeline.Controls;
using System;

namespace Timeline.Views;

public partial class MainWindow : Window
{
    private int offset = 0;

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
        offset++;
        this.FindControl<TimelineContainer>("Timeline").Children.Add(new TimelineItem(offset*50) { Title = "Lettuce"});
    }
}