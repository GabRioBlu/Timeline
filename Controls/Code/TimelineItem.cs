using Avalonia.Controls;
using Avalonia;
using Avalonia.Media;
using System;

namespace Timeline.Controls;

public class TimelineItem : ContentControl
{
    // Avalonia Properties

    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<TimelineItem, string>(nameof(Title));

    // Constructor

    public TimelineItem()
    {
        Background = Brushes.Orange;
        Console.WriteLine("esfbhjdsgva");
    }

    // Properties

    public string Title
    {
        get { return GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public Point Offset { get; set; }
}