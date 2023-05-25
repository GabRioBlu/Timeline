using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using System.Collections.Specialized;

namespace Timeline.Controls;

public class TimelineContainer : Panel
{
    // Avalonia Properties

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

        // Don't pan if we aren't panning
        if (!mousePressed) return;

        // Change in mouse pos
        Point delta = e.GetCurrentPoint(this).Position - previousPoint;
        pos += delta;
        previousPoint = e.GetCurrentPoint(this).Position;

        // Get timeline bg control
        if (timelineBackground == null) timelineBackground = this.FindControl<TimelineBackground>("TimelineBackground");
        foreach (Control child in Children)
        {
            // The bg control doesn't move - it only moves the rendered objects
            if (child == timelineBackground)
            {    
                timelineBackground.pan = pos;
                timelineBackground.InvalidateMeasure();
                continue;
            }

            child.RenderTransform = new TranslateTransform((child.RenderTransform != null ? child.RenderTransform.Value.M31 : 0) 
                    + delta.X, (child.RenderTransform != null ? child.RenderTransform.Value.M32 : 0) + delta.Y);
        }
    }

    // Methods

    

    // Properties
    bool mousePressed = false;
    Point pos = new Point();
    Point previousPoint = new Point();
    TimelineBackground? timelineBackground;
}