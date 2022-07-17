using System.Collections.Generic;
using ConsoleAppBlind75.MergeIntervals;
using NUnit.Framework;

namespace Blind75.Test.MergedIntervalTest
{
    [TestFixture]
    public class MergeIntervalTests
    {
        [Test]
        public void MergeIntervalTests1()
        {
            var listOfInterval = new List<Interval>()
            {
                new() { Start = 1, End = 4 },
                new() { Start = 2, End = 5 },
                new() { Start = 7, End = 9 }
            };

            var mergedIntervalResult = new MergeIntervalsOfOverlap().Execute(listOfInterval);
            
            Assert.AreEqual(mergedIntervalResult.Count, 2);
        }
        
        [Test]
        public void MergeIntervalTestInsertion()
        {
            var listOfInterval = new List<Interval>()
            {
                new() { Start = 1, End = 3 },
                new() { Start = 5, End = 7 },
                new() { Start = 8, End = 12 }
            };

            var mergedIntervalResult = new MergeIntervalsOfOverlap().ExecuteInsertInterval(listOfInterval, 
                new Interval(){ Start = 4, End = 6});
            
            Assert.AreEqual(mergedIntervalResult.Count, 2);
        }
    }
}