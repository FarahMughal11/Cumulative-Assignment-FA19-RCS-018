using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    public GameObject panelformainmenu;
    public GameObject panelforhummingbird;
    public GameObject panelformlagents;
    public GameObject panelforcomputationalmodel;
   // public GameObject panelforpalindrome;
    public GameObject panelforparenthesis;
    public GameObject coursepanel;
    public GameObject linkpanel;
    public GameObject palindromelanguage;
    public GameObject parenthesislanguage;
    // Start is called before the first frame update
    void Start()
    {
        panelformainmenu.SetActive(true);
    }
    //6 buttons of main menue 
    /*public void MLAgents()
    {
        Debug.Log("MLAgents ");
        panelformlagents.SetActive(true);
        panelformainmenu.SetActive(false);
    }*/
    public void mlagent()
    {
        panelformlagents.SetActive(true);
        panelformainmenu.SetActive(false);
    }
    public void ComputationalModel()
    {
        panelforcomputationalmodel.SetActive(true);
        panelformainmenu.SetActive(false);
    }
    public void matchingparanthesis()
    {
        panelforparenthesis.SetActive(true);
        panelformainmenu.SetActive(false);
        parenthesislanguage.SetActive(false);
    }
    public void panelcourse()
    {
        coursepanel.SetActive(true);
    }
    public void linkpanelon()
    {
        linkpanel.SetActive(true);
    }
    public void openniazilab()
    {
        Application.OpenURL("http://www.niazilab.com");
    }

    public void Quit()
    {
        // Application.Quit();
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
        #endif
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }

    //3 buttons of mlagent
    public void Penguingame()
    {
        SceneManager.LoadScene("Penguins");
    }
    public void Hummingbirdmenu()
    {
        panelforhummingbird.SetActive(true);
        panelformainmenu.SetActive(false);
    }
    public void back()
    {
        panelformainmenu.SetActive(true);
        //coursepanel.SetActive(false);
        //linkpanel.SetActive(false);
        panelforhummingbird.SetActive(false);
        //panelformlagents.SetActive(false);
    }
    public void backml()
    {
        panelformlagents.SetActive(false);
        panelformainmenu.SetActive(true);
    }
    //hummingbird panel
    public void HummingAgent()
    {
        SceneManager.LoadScene("Training");
    }
    public void Battlewithmlagent()
    {
        SceneManager.LoadScene("Flowerisland");
    }
    //buttons of computational models
    public void palindromelanguageclicked()
    {

        palindromelanguage.SetActive(true);

    }
    public void palindromeworld()
    {
        SceneManager.LoadScene("Roll-a-Ball");
    }
    public void computationreturn()
    {
        panelforcomputationalmodel.SetActive(false);
        panelformainmenu.SetActive(true);
    }
    //panel for matching paranthesis
    public void parehnthesislanguageclicked()
    {

        parenthesislanguage.SetActive(true);

    }

    public void parenthesisworld()
    {
        SceneManager.LoadScene("Terrain");
    }
    public void parenthesisreturn()
    {
        panelforparenthesis.SetActive(false);
        panelformainmenu.SetActive(true);
    }
    //for closing course panel, link panel and languages panels
    public void PalindromeLanguagecross()
    {

        palindromelanguage.SetActive(false);
        panelforcomputationalmodel.SetActive(true);

    }

    public void ParenthesisLanguagecross()
    {

        parenthesislanguage.SetActive(false);
        panelforparenthesis.SetActive(true);
    }

    public void crosscoursepanel()
    {
        coursepanel.SetActive(false);
        panelformainmenu.SetActive(true);
    }
    public void crosslinkpanel()
    {
        linkpanel.SetActive(false);
        panelformainmenu.SetActive(true);
    }

}