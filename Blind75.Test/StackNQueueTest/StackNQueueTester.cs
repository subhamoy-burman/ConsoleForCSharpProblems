using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleAppBlind75.StackNQueue;
using NUnit.Framework;

namespace Blind75.Test.StackNQueueTest
{
    [TestFixture]
    public class StackNQueueTester
    {
        [Test]
        public void DetectDuplicateBracket()
        {
            String str = "(((a+(b))+(c+d)))";
            String str1 = "((a+b)+((c+d)))";

            var isDuplicate = StackPrograms.DetectDuplicateBracket(str1);
        }
        
        [Test]
        public void TestFindNextGreaterElementInArray()
        {
            int[] array = new[] {11, 13, 21, 3};

            var isDuplicate = StackPrograms.FindNextGreaterElementInArray(array);
        }

        [Test]
        public void TestSortStack()
        {
            Stack s = new Stack();
            s.Push(30);
            s.Push(-5);
            s.Push(18);
            s.Push(14);
            s.Push(-3);
            
            StackPrograms.SortStack(s);
        }

        [Test]
        public void TesRottenOranges()
        {
            /*{ { 2, 1, 0, 2, 1 },
                      { 1, 0, 1, 2, 1 },
                      { 1, 0, 0, 2, 1 } };*/
            int[,] rottenCords = { { 2, 1, 0, 2, 1 },
                      { 1, 0, 1, 2, 1 },
                      { 1, 0, 0, 2, 1 } };

            StackPrograms.DetectRottenOranges(rottenCords);
        }

        [Test]
        public void TestPolishNotation()
        {
            var result = StackPrograms.ResultOfPolishNotation(new[] {'2', '1', '+', '3', '*'});
        }
    }
}