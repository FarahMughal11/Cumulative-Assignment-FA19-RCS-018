using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Specialized;

public class TerrainPlayer : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    private static bool check;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
        check = false;
        count = 0;
        SetCountText();
        winText.text = "";
        Panel.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pick Up"))
        {
            if (IsBalanced(collision.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text.ToString()))
            {
                collision.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
            else
            {
                collision.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public static bool IsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' }
        };



        Stack<char> brackets = new Stack<char>();



        try
        {
            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // check if the character is one of the 'opening' brackets
                if (bracketPairs.Keys.Contains(c))
                {
                    // if yes, push to stack
                    brackets.Push(c);
                }
                else
                // check if the character is one of the 'closing' brackets
                    if (bracketPairs.Values.Contains(c))
                {
                    // check if the closing bracket matches the 'latest' 'opening' bracket
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        // if not, its an unbalanced string
                        return false;
                }
                else
                    // continue looking
                    continue;
            }
        }
        catch
        {
            // an exception will be caught in case a closing bracket is found, 
            // before any opening bracket.
            // that implies, the string is not balanced. Return false
            return false;
        }



        // Ensure all brackets are closed
        return brackets.Count() == 0 ? true : false;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= TerrainBlocks.ParenthesisCount)
        {
           // panel.transform.GetChild(0).GetComponent<Text>().text = "Congratulations! You have Collected all " + InstnatiationTerrain.ParenthesisCount + " Palindrome Cubes";
            Panel.SetActive(true);
            winText.text = "Total Score:" + count.ToString();
        }
    }
}
