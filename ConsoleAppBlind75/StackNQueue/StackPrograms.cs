using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppBlind75.StackNQueue
{
    public static class StackPrograms
    {
        public static bool DetectDuplicateBracket(string characterString)
        {
            Stack<char> characterStack = new Stack<char>();
            foreach (var character in characterString.ToCharArray())
            {
                if (character != ')')
                {
                    characterStack.Push(character);
                }
                else
                {
                    if (characterStack.Peek() == '(')
                    {
                        return false;
                    }

                    while (characterStack.Peek()!='(')
                    {
                        characterStack.Pop();
                    }

                    characterStack.Pop();
                }
            }

            return true;
        }

        public static List<int> FindNextGreaterElementInArray(int[] inputArray)
        {
            List<int> resultArray = new List<int> {-1};
            Stack<int> processorStack = new Stack<int>();
            processorStack.Push(inputArray.LastOrDefault());

            for (int i = inputArray.Length-2; i >= 0; i--)
            {
                if (processorStack.Count > 0)
                {
                    while (processorStack.Count>0 && processorStack.Peek() < inputArray[i])
                    {
                        processorStack.Pop();
                    }

                    if (processorStack.Count > 0)
                    {
                        resultArray.Insert(0,processorStack.Peek());
                    }
                    else
                    {
                        resultArray.Insert(0,-1);
                    }
                }
                else
                {
                    resultArray.Insert(0,-1);
                }

                processorStack.Push(inputArray[i]);
            }

            return resultArray;
        }
        
        static void SortedInsert(Stack s, int x)
        {
            // Base case: Either stack is empty or
            // newly inserted item is greater than top
            // (more than all existing)
            if (s.Count == 0 || x > (int)s.Peek()) {
                s.Push(x);
                return;
            }
 
            // If top is greater, remove
            // the top item and recur
            int temp = (int)s.Peek();
            s.Pop();
            SortedInsert(s, x);
 
            // Put back the top item removed earlier
            s.Push(temp);
        }
 
        // Method to sort stack
        public static void SortStack(Stack s)
        {
            // If stack is not empty
            if (s.Count > 0) {
                // Remove the top item
                int x = (int)s.Peek();
                s.Pop();
 
                // Sort remaining stack
                SortStack(s);
 
                // Push the top item back in sorted stack
                SortedInsert(s, x);
            }
        }

        public class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coordinates(int xCordinate, int yCordinate)
            {
                X = xCordinate;
                Y = yCordinate;
            }
        }
        
        public static int DetectRottenOranges(int[,] oranges)
        {
            if (oranges.GetLength(0) == 0 && oranges.GetLength(1) == 0)
            {
                return -1;
            }

            int totalNumberOfDaysToRot = 0;
            int totalNumberOfOranges = 0;
            int totalNumberOfRottenOranges = 0;

            Queue<Coordinates> rottenCoordinates = new Queue<Coordinates>();
            for (int i = 0; i < oranges.GetLength(0); i++)
            {
                for (int j = 0; j < oranges.GetLength(1); j++)
                {
                    if (oranges[i,j] == 1)
                    {
                        totalNumberOfOranges++;
                    }
                    if (oranges[i,j] == 2)
                    {
                        totalNumberOfOranges++;
                        rottenCoordinates.Enqueue(new Coordinates(i,j));
                    }
                }
            }

            int[] deltaX = {0, 0, 1, -1};
            int[] deltaY = {1, -1, 0, 0};

            while (rottenCoordinates.Count!=0)
            {
                int rottenSize = rottenCoordinates.Count;
                totalNumberOfRottenOranges += rottenSize;
                
                while (rottenSize-->0)
                {
                    Coordinates peekQueueData = rottenCoordinates.Peek();
                    rottenCoordinates.Dequeue();
                    
                    for (int i = 0; i < 4; i++)
                    {
                        int nextXCoordinate = peekQueueData.X + deltaX[i];
                        int nextYCoordinate = peekQueueData.Y + deltaY[i];

                        if (nextXCoordinate < 0 || nextYCoordinate < 0 || nextXCoordinate >= oranges.GetLength(0) ||
                            nextYCoordinate >= oranges.GetLength(1) || oranges[nextXCoordinate,nextYCoordinate]!=1)
                        {
                            continue;
                        }

                        oranges[nextXCoordinate,nextYCoordinate] = 2;
                        rottenCoordinates.Enqueue(new Coordinates(nextXCoordinate, nextYCoordinate));
                    }
                    if (rottenCoordinates.Count > 0)
                    {
                        totalNumberOfDaysToRot++;
                    }
                }
            }

            return totalNumberOfRottenOranges != totalNumberOfOranges ? totalNumberOfDaysToRot: -1;

        }

        public static int ResultOfPolishNotation(char[] input)
        {
            Stack<int> processStack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (currentChar != '*' && currentChar != '+' && currentChar != '/' && currentChar != '-')
                {
                    processStack.Push(currentChar - '0');
                }
                else
                {
                    var stackFirstOperand = processStack.Pop();
                    var stackSecondOperand = processStack.Pop();
                    int result = 0;

                    switch (currentChar)
                    {
                        case '*':
                            result = stackSecondOperand * stackFirstOperand;
                            break;
                        case '+':
                            result = stackSecondOperand + stackFirstOperand;
                            break;
                        case '-':
                            result = stackSecondOperand - stackFirstOperand;
                            break;
                        case '/':
                            if (stackSecondOperand / stackFirstOperand < 0)
                            {
                                result = 0;
                            }
                            else
                            {
                                result = stackSecondOperand / stackFirstOperand;
                            }
                            break;
                                
                    }
                    processStack.Push(result);
                }
            }

            return processStack.Pop();
        }
    }
}