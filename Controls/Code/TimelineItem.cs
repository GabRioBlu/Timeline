using Avalonia.Controls;
using Avalonia;
using Avalonia.Media;
using System;

namespace Timeline.Controls;

public class TimelineItem : ContentControl
{
    // Avalonia Properties

    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<TimelineItem, string>(nameof(Title));

    public static readonly StyledProperty<DateTime> TimeProperty = AvaloniaProperty.Register<TimelineItem, DateTime>(nameof(Time), DateTime.Now);

    // Constructor

    public TimelineItem()
    {
        Background = Brushes.Orange;
        this.RenderTransform = new TranslateTransform((Time.Year-2020)*50 + (Time.DayOfYear-1)*50/365, -40);
    }

    // Properties

    public string Title
    {
        get { return GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public DateTime Time
    {
        get { return GetValue(TimeProperty); }
        set { SetValue(TimeProperty, value); }
    }

    public Point Offset { get; set; }
}