using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
        Panel.SetActive(false);
        count = 0;
        SetCountText();
        winText.text = "";
        check = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Pick Up"))
        {
            if (IsPalindrome(collision.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text.ToString()))
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

    public static bool IsPalindrome(string text)
    {
        if (text.Length <= 1)
            return true;
        else
        {
            if (text[0] != text[text.Length - 1])
                return false;
            else
                return IsPalindrome(text.Substring(1, text.Length - 2));
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
       if (count >= BlocksCreation.PalinCount)
        {
            Panel.SetActive(true);
            winText.text = "Total Score:" + count.ToString();
        }
    }
}
