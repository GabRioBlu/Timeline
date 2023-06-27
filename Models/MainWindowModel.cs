using System;

namespace Timeline.Models;

public class TimelineModels
{
    private static string[] randomTitles = { "Lettuce", "aaaaa", "what do i write here", "This is a test event.",
            "this isn't a test event lol" };

    public static string RandomTitle()
    {
        var rand = new Random();

        return randomTitles[rand.NextInt64(randomTitles.Length)];
    }
}