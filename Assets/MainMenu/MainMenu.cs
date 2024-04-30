using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    //public void PlayGame() -- TO ZDEJ SCENELOADER NARDI
    //{
    //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NinjaScreen()
    {
        SceneManager.LoadScene(3);
    }

}
