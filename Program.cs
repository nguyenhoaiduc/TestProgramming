using System;
using System.Linq;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        if (n != input.Length) return;

        //Convert string array input to integer array
        int[] inputArray = input.Select(int.Parse).ToArray();

        //maxSum[i] is the maxSum the thief can achieve till he arrrives to the ith house
        int[] maxSum = new int[n];

        //Initialize maxSum
        maxSum[0] = inputArray[0];
        maxSum[1] = (inputArray[1] > inputArray[0]) ? inputArray[1] : inputArray[0];
        
        for(int i = 2; i < n; i++)
        {
            //Assume that the thief knows all the maxsum till the i-1_th house
            //He have to decide to steal the i_th house or not
            // If yes, he have to skip i-1_th house, and take the maxSum till i-2_th house in plus.
            // If no, the sum remains as maxSum till i-1_th house.
            maxSum[i] = Math.Max(maxSum[i - 1], maxSum[i - 2] + inputArray[i]);
        }

        Console.WriteLine(maxSum[n-1]);
    }
}