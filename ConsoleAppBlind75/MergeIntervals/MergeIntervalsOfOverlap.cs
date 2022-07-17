using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppBlind75.FastSlowPointer;

namespace ConsoleAppBlind75.MergeIntervals
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
    
    public class MergeIntervalsOfOverlap
    {
        public List<Interval> Execute(List<Interval> intervals)
        {
            List<Interval> mergedInterval = new List<Interval>();
            var orderedInterval = intervals.OrderBy(x=>x.Start);
            
            mergedInterval.Add(orderedInterval.FirstOrDefault());

            foreach (var item in orderedInterval)
            {
                var lastElement = mergedInterval.LastOrDefault();
                if (item.Start > lastElement!.Start && item.Start > lastElement!.End)
                {
                    mergedInterval.Add(item);
                    continue;
                }
                if (item.Start < lastElement!.Start && item.End < lastElement!.End)
                {
                    continue;
                }

                if (item.Start > lastElement!.Start && item.End > lastElement!.Start)
                {
                    if (item.End > lastElement!.End)
                    {
                        lastElement.End = item.End;
                    }
                }
                
            }

            return mergedInterval;
        }

        public List<Interval> ExecuteInsertInterval(List<Interval> intervals, Interval newInterval)
        {
            List<Interval> mergedInterval = new List<Interval>();
            var orderedInterval = intervals.OrderBy(x=>x.Start).ToList();

            int index = 0;

            while (index < intervals.Count)
            {
                if (orderedInterval[index].Start < newInterval.Start)
                {
                    mergedInterval.Add(orderedInterval[index]);
                    index++;
                }
                else
                {
                    break;
                }
            }

            if (mergedInterval.Count == 0 || mergedInterval.LastOrDefault()!.End < newInterval.Start)
            {
                mergedInterval.Add(newInterval);
            }
            else
            {
                mergedInterval.LastOrDefault()!.End = Math.Max(mergedInterval.LastOrDefault()!.End, newInterval.End);
            }

            while (index < intervals.Count)
            {
                var lastInterval = mergedInterval.LastOrDefault();
                if (lastInterval!.End >= intervals[index].Start)
                {
                    mergedInterval.LastOrDefault()!.End =
                        Math.Max(mergedInterval.LastOrDefault()!.End, intervals[index].End);
                }
                else
                {
                    mergedInterval.Add(intervals[index]);
                }

                index++;
            }

            return mergedInterval;
        }
    }
}