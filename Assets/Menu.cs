using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onPlayButton()
    {
        //this is the 2nd scene technically since we start counting at 0
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
