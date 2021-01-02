using System;
using System.Collections.Generic;
using System.Linq;

namespace Check_Array_Formation_Through_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 5, 7 };
            int[][] pieces = new int[3][];
            pieces[0] = new int[] { 1 };
            pieces[1] = new int[] { 7 };
            pieces[2] = new int[] { 3, 5 };
            Console.WriteLine(CanFormArray_Dictionary(arr, pieces));
        }

        static bool CanFormArray(int[] arr, int[][] pieces)
        {
            foreach (var piece in pieces)
            {
                int lastIndexFoundAt = -1;
                foreach (int i in piece)
                {
                    if (!arr.Contains(i)) return false;
                    int currentIndex = Array.IndexOf(arr, i);
                    if ((lastIndexFoundAt != -1) && (currentIndex != (lastIndexFoundAt + 1))) return false;
                    lastIndexFoundAt = currentIndex;
                }
            }
            return true;
        }

        static bool CanFormArray_Dictionary(int[] arr, int[][] pieces)
        {
            Dictionary<int, int[]> tracker = new Dictionary<int, int[]>();
            foreach (var piece in pieces)
                tracker.Add(piece[0], piece);
            int i = 0;
            while(i < arr.Length)
            {
                if (!tracker.ContainsKey(arr[i])) return false;
                var piece = tracker[arr[i]];
                foreach (int j in piece)
                {
                    if (arr[i] != j) return false;
                    else i++;
                }
            }

            return true;
        }
    }
}
