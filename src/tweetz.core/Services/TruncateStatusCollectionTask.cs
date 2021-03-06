﻿using System.Threading.Tasks;
using tweetz.core.Models;

namespace tweetz.core.Services
{
    public static class TruncateStatusCollectionTask
    {
        public static ValueTask Execute(TwitterTimeline timeline)
        {
            const int maxNumberOfStatuses = 500;

            while (timeline.StatusCollection.Count > maxNumberOfStatuses)
            {
                timeline.StatusCollection.RemoveAt(timeline.StatusCollection.Count - 1);
            }

            return default;
        }
    }
}