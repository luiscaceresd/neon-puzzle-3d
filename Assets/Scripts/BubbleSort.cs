using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    // Main
    void Start()
    {
        int[] array = {64, 34, 25, 12, 22, 11, 90};
        Debug.Log("Unsorted array");
        PrintArray(array);

        //bubble sort
        BubbleSortExample(array);
        Debug.Log("Sorted array");
        PrintArray(array);
    }

    private static void BubbleSortExample(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // swap temp and arr[i]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }   

    private static void PrintArray(int[] array)
    {
        foreach(var item in array)
        {
            Debug.Log(""+item);
        }
    }
}
