using ConsoleNeetCode.RevisionOne.Graphs;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test
{
    public class DisjointSetTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDisjointTest()
        {
            DisjointSet disjointSet = new DisjointSet(8);
            disjointSet.UnionByRank(1,2);
            disjointSet.UnionByRank(2,3);
            disjointSet.UnionByRank(4,5);
            disjointSet.UnionByRank(6,7);
            disjointSet.UnionByRank(5,6);
            
            Assert.AreNotEqual(disjointSet.FindUltimateParent(3), disjointSet.FindUltimateParent(7));
            
            disjointSet.UnionByRank(3,7);
            
            Assert.AreEqual(disjointSet.FindUltimateParent(3), disjointSet.FindUltimateParent(7));
        }
    }
}