using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System;
using Random = UnityEngine.Random;

public class SearchTest : MonoBehaviour
{
    private void Start()
    {
        int[] numbers = new int[500000];
        int loopAmount =        500000000;
        int target = 50;
        Search search = new BruteForceSearch();
        Search search2 = new BinarySearch();

      
        for(int x = 0; x < numbers.Length; x++)
        {
            numbers[x] = Random.Range(0, numbers.Length);
        }
        numbers[Random.Range(0, numbers.Length)] = target;
        Array.Sort(numbers);


        Stopwatch stopWatch = new Stopwatch();
        

        stopWatch.Start();
        for (int x = 0; x < loopAmount; x++)
        {
            search.Find(numbers, target);
        }
        stopWatch.Stop();

        print(stopWatch.ElapsedMilliseconds);


        stopWatch = new Stopwatch();
        loopAmount = 1000000;

        stopWatch.Start();
        for (int x = 0; x < loopAmount; x++)
        {
            search2.Find(numbers, target);
        }
        stopWatch.Stop();

        print(stopWatch.ElapsedMilliseconds);
    }
}
