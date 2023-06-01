using Avalonia.Controls;
using Avalonia;
using Avalonia.Media;
using System;

namespace Timeline.Controls;

public class TimelineItem : ContentControl
{
    // Avalonia Properties

    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<TimelineItem, string>(nameof(Title));

    public static readonly StyledProperty<int> TimeProperty = AvaloniaProperty.Register<TimelineItem, int>(nameof(Time), 1);

    // Constructor

    public TimelineItem()
    {
        Setup();
    }

    public TimelineItem(int time)
    {
        Time = time;
        Setup();
    }

    private void Setup()
    {
        Background = Brushes.Orange;
        Offset = new Point(Time, -40);
        //this.RenderTransform = new TranslateTransform((Time.Year-2020)*50 + (Time.DayOfYear-1)*50/355, -40);
    }

    // Properties

    public string Title
    {
        get { return GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public int Time
    {
        get { return GetValue(TimeProperty); }
        set { SetValue(TimeProperty, value); }
    }

    public Point Offset { get; set; }
}