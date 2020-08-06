using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BlocksCreation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    private Vector3 Cubes;
    private Vector3 Text;
    private bool tf;
    private float radius = 1;
    private int numofCubes = 10;
    private static System.Random random = new System.Random();
    public static int PalinCount;



    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        int i = 0;
       List<string> results = RandomString();
        while (numofCubes > 0)
        {

            Cubes = new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(0.5f, 0.5f), UnityEngine.Random.Range(1, 20));
           
            if (Physics.CheckSphere(Cubes, radius))
            {
            }
            else
            {
                Instantiate(myPrefab, Cubes, Quaternion.identity);
                Text = new Vector3(Cubes.x, Cubes.y, Cubes.z);
                myPrefab.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = results[i];
                i++;
                numofCubes = numofCubes - 1;
            }

        }

    }

    public static List<string> RandomString()
     {
         List<string> list_of_strings = new List<string>();
        int length;
        for (int i = 0; i <= 10; i++)
         {
            length = UnityEngine.Random.Range(9, 15);
            const string chars = "XF8";
            string val = new string(Enumerable.Repeat(chars, length)
               .Select(s => s[random.Next(s.Length)]).ToArray());

             list_of_strings.Add(val);
         }
         List<string> test = createPalindrome(list_of_strings);
         return test;
     }

    public static List<string> createPalindrome(List<string> val)
    {
        PalinCount = UnityEngine.Random.Range(3, 9);
        List<string> value = val;
        for (int i = 0; i < PalinCount; i++)
        {
            string first = val[i].Substring(0, val[i].Length / 2);
            char[] arr = first.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            val[i] = first + temp;
            value[i] = val[i];

        }
        return value;
    }
}
