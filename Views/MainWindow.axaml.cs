using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Timeline.Controls;
using System;
using Avalonia.Styling;
using Timeline.Models;
using Avalonia.Input;

namespace Timeline.Views;

public partial class MainWindow : Window
{
    private int offset = 0;

    private EditPanel editPanel;

    public MainWindow()
    {
        InitializeComponent();    

        editPanel = this.GetControl<EditPanel>("EditPanel");
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void AddEvent(object sender, RoutedEventArgs e)
    {
        offset++;
        var timeline = this.FindControl<TimelineContainer>("Timeline");

        var item = new TimelineItem(offset*50) { Title = TimelineModels.RandomTitle(), Classes = new Classes(new string[] {"TimelineItem"}) };

        item.AddHandler(PointerPressedEvent, ItemPressed);

        timeline.Children.Insert(timeline.Children.Count - 1, item);
    }

    public void ItemPressed(object? sender, PointerPressedEventArgs e)
    {
        editPanel.EditedItem = (TimelineItem)sender!;
    }
}