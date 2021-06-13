/*
 * Author: Jeff Leupold
 * Homework 4
 * Date: 2021-04-29 
*/

using System;
using System.Collections.Generic;

namespace Homework4 {
    class Program {
        static void Main(string[] args) {
            List<int[]> arrList = new List<int[]>();
            arrList.Add(new int[] {});  //always test empty/null cases because they can cause unexpected behavior
            arrList.Add(new int[] {0,1,2,3});   //even number of elements - subarrays are evenly split
            arrList.Add(new int[] {0,1,2,3,4}); //odd number of elements - special case when splitting array 
            arrList.Add(new int[] {3,1,4,1,5,9,2,6,5}); //odd number of elements, repeating values
            arrList.Add(new int[] {9,8,7,6,5,4,3,2,1,0});   //reverse of goal, could indicate worst case scenario
            //odd number of elements, testing negative numbers & negative number is in right split
            arrList.Add(new int[] {0,1,2,-3,4});
            //same as previous case except negative number is in left split 
            arrList.Add(new int[] {0,1,-2,3,4});
            arrList.Add(new int[] {42});    //testing simple case of one integer
            arrList.Add(new int[] {5,4,3,2,1,6,7,8,9}); //left half reverse, right half sorted
            arrList.Add(new int[]{1,2,3,4,5,9,8,7,6});  //left half sorted, right half reverse

            foreach (int[] a in arrList) {
                System.Console.WriteLine("pre-sort:");
                printArray(a);

                MergeSort(a, 0, a.Length - 1);
                
                Console.WriteLine("post sort:");
                printArray(a);
                System.Console.WriteLine("-----------------");
            }
        }

        public static void printArray(int[] arr2p) {
            string output = "";
            for (int i = 0; i < arr2p.Length; i++) {
                if (output.Equals("")) {
                    output = arr2p[i].ToString();   
                }
                else {
                    output += $", {arr2p[i]}";
                }
            }
            System.Console.WriteLine("[" + output + "]");
        }

        /*
        * Array are passed by reference in C# so no need to return anything
        */
        public static void MergeSort(int[] input, int lo, int hi) {
            if (hi - lo > 0) {
                //integer math so odd numbers are handled
                int mid = (lo + hi) / 2;
                MergeSort(input, lo, mid);
                MergeSort(input, mid + 1, hi);
                //stitch them back together
                MergeArrays(input, lo, hi);
            }
        }

        public static void MergeArrays(int[] arr, int lo, int hi) {
            int arrLength = hi - lo + 1;    //if indexes are 4 and 10, then there are 7 elements: 4,5,6,7,8,9,10
            int[] temp = new int[arrLength];
            int mid = (lo + hi) / 2;
            //create pointers for each Array and for temp
            int ptrA = lo;
            int ptrB = mid + 1; 
            int ptrTemp = 0;

            while (ptrA <= mid && ptrB <= hi) {
                if (arr[ptrA] < arr[ptrB]) 
                    temp[ptrTemp++] = arr[ptrA++];
                else
                    temp[ptrTemp++] = arr[ptrB++];
            }

            //insert leftover elements
            while (ptrA <= mid) {
                temp[ptrTemp++] = arr[ptrA++];
            }

            while (ptrB <= hi) {
                temp[ptrTemp++] = arr[ptrB++];
            }

            //copy contents of temp to arr
            for (int i = 0; i < arrLength; i++) {
                arr[lo + i] = temp[i];
            }
        }
    }
}
