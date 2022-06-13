using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ConsoleAppBlind75
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a number below to run the program...");
            Console.WriteLine("1. Max Product Subarray"); 
            Console.WriteLine("2. Find Minimum in rotated sorted array");
            Console.WriteLine("3. Find pivot in rotated sorted array");
            Console.WriteLine("4. Find average of contagious subarray os size k");
            Console.WriteLine("5. Find maximum in subarray of size k");
            Console.WriteLine("6. Smallest Subarray with a given sum");

            var selectedNumber = Convert.ToInt32(Console.ReadLine());
            switch(selectedNumber) 
            {
                case 1:
                    MaxProduct(new int[] {2, 3, 1, 8, 4, 6, 2});
                    break;
                case 2:
                    new FindMinimumInRotatedSortedArray().Execute(new int[] { 4, 5, 6, 7, 8, 0, 1, 3});
                    break;
                case 3:
                    new FindPivotOfRotatedSortedArray().Execute(new int[] { 4, 5, 6,7, 8 ,0, 1, 2 });
                    break;
                case 4:
                    new FindAverageOfContagiousSubArrayOfSizeK().Execute(new int[] { 1, 3, 2,6, -1 ,4, 1,8, 2 }, 5);
                    break;
                case 5: 
                    new FindMaximumSubArraySumOfSizeK().Execute(new int[] { 2,1,5,1,3,2},3);
                    break;
                case 6:
                    new FindSmallestSubArrayOfGivenSum().Execute(new int[] {2, 1, 5, 2, 3, 2}, 7);
                    break;
            }

            
            Console.Read();
        }
        
        
        
        public static int MaxProduct(int[] nums) {
        
            int currentProduct = nums[0];
            int overAllProduct = nums[0];
        
            for(int i=1;i<nums.Length;i++)
            {
                if((currentProduct * nums[i])>0)
                {
                    currentProduct *= nums[i];
                }
                else
                {
                    currentProduct = nums[i];
                }
            
                if(overAllProduct < currentProduct)
                {
                    overAllProduct = currentProduct;
                }
            }
        
            return overAllProduct;
        }
        
        private static int[] ProductExceptSelf(int[] nums) {
        
            int productWithoutZero = 1;
            bool isAnyItemZero = false;
            bool isAllItemZero = true;
        
            foreach(var item in nums)
            {
                if(item!=0)
                {
                    isAllItemZero = false;
                    productWithoutZero = productWithoutZero*item;
                }
                else
                {
                    isAnyItemZero = true;
                }
            
            }
        
            if(isAllItemZero)
            {
                productWithoutZero = 0;
            }
        
            List<int> resultList = new List<int>();
        
            foreach(var item in nums)
            {
                if(item!=0 && isAnyItemZero)
                {
                    resultList.Add(0);
                }
                else if(item!=0 && !isAnyItemZero)
                {
                    resultList.Add(productWithoutZero/item);
                }
                else if(item ==0)
                {
                    resultList.Add(productWithoutZero);
                }
            
            }
        
            return resultList.ToArray();
        }
    }
}