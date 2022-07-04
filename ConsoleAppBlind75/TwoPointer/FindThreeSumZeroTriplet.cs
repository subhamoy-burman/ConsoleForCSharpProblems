using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleAppBlind75.TwoPointer
{
    public class FindThreeSumZeroTriplet
    {
        public int ExecuteBruteForce(int[] arr)
        {
            int tripletCount = 0;
            for (int i = 0; i <= arr.Length-3; i++)
            {
                for (int j = i+1; j <= arr.Length-2; j++)
                {
                    for (int k = j+1; k <= arr.Length-1; k++)
                    {
                        if ((arr[i] + arr[j] + arr[k]) == 0)
                        {
                            Debug.WriteLine($"{arr[i]}  {arr[j]}  {arr[k]}");
                            tripletCount++;
                        }
                    }
                }
            }
            return tripletCount;
        }

        public void ExecuteTwoExtraSpace(int[] arr)
        {
            bool found = false;
  
            for (int i = 0; i < arr.Length - 1; i++) 
            {
                // Find all pairs with sum equals to
                // "-arr[i]"
                HashSet<int> s = new HashSet<int>();
                for (int j = i + 1; j < arr.Length; j++) 
                {
                    int x = -(arr[i] + arr[j]);
                    if (s.Contains(x)) 
                    {
                        Debug.WriteLine("{0} {1} {2}\n", x, arr[i], arr[j]);
                        found = true;
                    } 
                    else
                    {
                        s.Add(arr[j]);
                    }
                }
            }
  
            if (found == false)
            {
                Console.Write(" No Triplet Found\n");
            }
        }
        
        public void ExecuteTwoPointer(int[] arr)
        {
            Array.Sort(arr);
            int left = 0;
            int right = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                left = i;
                right = arr.Length - 1;

                int x = arr[i];
    
                while (left < right)
                {
                    if (x + arr[left] + arr[right] == 0)
                    {
                        Debug.WriteLine($"{x}  {arr[left]} {arr[right]}");
                        left++;
                        right--;
                        continue;
                    }
                    if( x + arr[left] + arr[right] > 0)
                    {
                        left++;
                        continue;
                    }
                    if( x+ arr[left] + arr[right] < 0)
                    {
                        right--;
                    }
                    
                    
                }
                    
            }
        }
    }
}