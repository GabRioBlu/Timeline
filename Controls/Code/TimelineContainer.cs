using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

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
        foreach (var child in Children)
        {
            if (child is TimelineItem item)
            {
                child.RenderTransform = new TranslateTransform(item.Offset.X + pos.X, item.Offset.Y + pos.Y);
            } 
            else if (child is TimelineBackground bg)
            {
                // The bg control doesn't move - it only moves the rendered objects
                bg.pan = pos;
                bg.InvalidateMeasure();
            }

        }
    }

    // Methods
    
    protected override Size ArrangeOverride(Size finalSize)
    {
        IControl? previousChild = null;
        foreach (var child in Children)
        {   
            if (child is TimelineItem item)
            {
                item.RenderTransform = new TranslateTransform(item.Offset.X + pos.X, item.Offset.Y + pos.Y);
                if (previousChild != null)
                {
                    TimelineItem prev = (TimelineItem)previousChild;

                    for (int i = (int)(VisualChildren.IndexOf(child) + prev.Offset.Y/40); i < VisualChildren.IndexOf(child); i++)
                    {
                        TimelineItem prevItem = ((TimelineItem)VisualChildren[i]);

                        Console.WriteLine("Start");
                        Console.WriteLine(item.Time);
                        Console.WriteLine(prevItem.Offset);
                        Console.WriteLine(prevItem.Offset.Y == item.Offset.Y);
                        Console.WriteLine(prevItem.Offset.X + VisualChildren[i].VisualChildren[0].Bounds.Width/2);
                        Console.WriteLine(item.Offset.X - child.VisualChildren[0].Bounds.Width/2);
                        Console.WriteLine(child.DesiredSize);
                        Console.WriteLine("End");

                        if (prevItem.Offset.Y == item.Offset.Y && prevItem.Offset.X + prevItem.DesiredSize.Width/2 > item.Offset.X - child.DesiredSize.Width/2)
                        {
                            item.Offset = new Point(item.Offset.X, item.Offset.Y - 40);
                            item.RenderTransform = new TranslateTransform(item.Offset.X + pos.X, item.Offset.Y + pos.Y);
                        }
                    }
                    
                }
                item.InvalidateArrange();
                previousChild = child;
                continue;
            }

            child.Arrange(new Rect(new Point(0, 0), finalSize));
            child.InvalidateArrange();
        }

        return base.ArrangeOverride(finalSize);
    }

    // Properties
    bool mousePressed = false;
    Point pos = new Point();
    Point previousPoint = new Point();
}