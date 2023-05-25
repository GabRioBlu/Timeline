using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace Timeline.Controls;

public class TimelineContainer : Panel
{
    // Properties

    // Constructor
    public TimelineContainer()
    {

    }

    // Events

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        mousePressed = true;
        previousPoint = e.GetCurrentPoint(this).Position;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        mousePressed = false;

        // Point delta = e.GetCurrentPoint(this).Position - mouseStart;
        // pos += delta;
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        if (!mousePressed) return;

        Point delta = e.GetCurrentPoint(this).Position - previousPoint;
        pos += delta;
        previousPoint = e.GetCurrentPoint(this).Position;

        if (timelineBackground == null) timelineBackground = this.FindControl<TimelineBackground>("TimelineBackground");
        foreach (Control child in Children)
        {
            if (child == timelineBackground)
            {    
                timelineBackground.pan = pos;
                timelineBackground.InvalidateMeasure();
                continue;
            }
            child.RenderTransform = new TranslateTransform(pos.X, pos.Y);
        }
    }

    // Methods

    // protected override void ArrangeCore(Rect finalRect)
    // {
    //     Console.WriteLine("ArrangeCore()");
    //     base.ArrangeCore(finalRect);
    // }

    // protected override Size ArrangeOverride(Size finalSize)
    // {
    //     Console.WriteLine("ArrangeOverride()");
    //     return base.ArrangeOverride(finalSize);
    // }

    // Fields
    bool mousePressed = false;
    Point pos = new Point();
    Point previousPoint = new Point();
    TimelineBackground? timelineBackground;
}