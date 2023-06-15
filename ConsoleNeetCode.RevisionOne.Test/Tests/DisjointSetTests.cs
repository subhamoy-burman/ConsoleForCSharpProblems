using System.Collections.Generic;
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

        [Test]
        public void TestDisjointTest2()
        {
            DisjointSetRevision1 ds = new DisjointSetRevision1(7);
            ds.UnionByRank(1, 2);
            ds.UnionByRank(2, 3);
            ds.UnionByRank(4, 5);
            ds.UnionByRank(6, 7);
            ds.UnionByRank(5, 6);

            // Check if 3 and 7 are in the same set
            
            
            Assert.AreNotEqual(ds.FindUltimateParent(3), ds.FindUltimateParent(7));

            ds.UnionByRank(3, 7);
            Assert.AreEqual(ds.FindUltimateParent(3), ds.FindUltimateParent(7));

            // if (ds.FindUPar(3) == ds.FindUPar(7))
            // {
            //     Console.WriteLine("Same");
            // }
            // else
            // {
            //     Console.WriteLine("Not Same");
            // }
        }
        
        
        
        
    }
}