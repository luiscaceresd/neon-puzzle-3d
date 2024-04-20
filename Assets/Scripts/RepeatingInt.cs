using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingInt : MonoBehaviour
{
    // MAIN
    void Start()
    {
        //input is an array x of n values
        // -9 <= x[i] <= 40
        int[] x = { 10, 3, 0, -4, 2, 0, -8 };

        //find and print to debug log the repeating integer
        Debug.Log("Repeating integer: " + RepeatingIntExample(x));
    }

    //function to find the repeating integer in a given array
    private static int RepeatingIntExample(int[] array)
    {
        int n = array.Length;
        int repeatingInt = 0;
        int[] z = new int[50]; 

        for (int i = 0; i < n; i++)
        {
            if (z[array[i] + 9] == 1) // Adjust the index to match the range of values
            {
                repeatingInt = array[i];
                break;
            }
            else
            {
                z[array[i] + 9]++; // Adjust the index to match the range of values
            }
        }

        return repeatingInt;
    }
}
