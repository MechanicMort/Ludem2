using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject menu;
    public GameObject control;
    


    public void startGame()// set next scene number
    {
        FadeToLevel();        
    }

    public void FadeToLevel() // declare varibles and run animation
    {
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() // load next level
    {
        SceneManager.LoadScene(1);
    }
    
    



    public void controls() // open the controls
    {
        flash();
        menu.SetActive(false);        
        control.SetActive(true);
    }

    public void returnMenu()// open the menu
    {
        flash();        
        control.SetActive(false);
        menu.SetActive(true);
    }
    
    

    public void flash() // hold animation for screen flashing black
    {
        anim.SetTrigger("BlackFlash");
    }







    public void quit() // allow the user to quit the game
    {
        Debug.Log("Quit");
        anim.SetTrigger("Quit");
    }

    public void OnFadeQuit()
    {
        Application.Quit();
    }


}
