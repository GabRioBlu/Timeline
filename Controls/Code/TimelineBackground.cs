using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Timeline.Controls;

public class TimelineBackground : Control
{
    // Avalonia Properties

    /// <Summary>
    /// Background colour.
    /// </Summary>
    public static readonly StyledProperty<IBrush> BackgroundProperty = AvaloniaProperty.Register<TimelineBackground, IBrush>(
        nameof(Background), new SolidColorBrush(new Color(255, 25, 6, 51)));

    // Methods

    /// <Summary>
    /// Renders the "background": The center line, grid lines, things that don't change.
    /// </Summary>
    public override void Render(DrawingContext context)
    {
        base.Render(context);

        // Fill background
        context.FillRectangle(Background, this.Bounds);

        Point leftPoint = new Point(0, this.Bounds.Height / 2 + pan.Y);
        Point rightPoint = new Point(this.Bounds.Width, this.Bounds.Height / 2 + pan.Y);

        // Draw center line
        context.DrawLine(new Pen(Brushes.White, 10), leftPoint, rightPoint);

        // First point on the left - may be off screen, but it doesn't matter
        double firstPointPos = 0 - (50 - (this.Bounds.Width/2 + pan.X) % 50);

        for (int i = 0; i < Math.Ceiling(this.Bounds.Width/50)+2; i++)
        {
            // Points are spaced by 50 pixels (NOTE: make this relative to window size later)
            double x = firstPointPos + i * 50;
            Point pos = new Point(x, this.Bounds.Height / 2 + pan.Y);

            // Center point is slightly larger
            if (x - pan.X == this.Bounds.Width/2)
            {
                context.DrawEllipse(Brushes.White, null, pos, 15, 15);
                continue;
            }

            context.DrawEllipse(Brushes.White, null, pos, 10, 10);
        }
    }

    // Properties

    /// <Summary>
    /// Scroll offset.
    /// </Summary>
    public Point pan = new Point();

    public IBrush Background
    {
        get { return this.GetValue(TimelineBackground.BackgroundProperty); }
        set
        {
            this.SetValue(TimelineBackground.BackgroundProperty, value);
            InvalidateVisual();
        }
    }
}