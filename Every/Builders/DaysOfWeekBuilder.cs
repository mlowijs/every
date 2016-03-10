﻿using System.Linq;

namespace Every.Builders
{
    public class DayOfWeekBuilder : AtBuilder
    {
        internal DayOfWeekBuilder(JobConfiguration config)
            : base(config)
        {
            while (!Configuration.DaysOfWeek.Contains(Configuration.First.DayOfWeek))
                Configuration.First = Configuration.First.AddDays(1);

            Configuration.CalculateNext = job =>
            {
                var next = job.Next;

                do
                    next = next.AddDays(1);
                while (!Configuration.DaysOfWeek.Contains(next.DayOfWeek));

                return next;
            };
        }
    }
}