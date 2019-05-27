using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() 
    {
        SceneManager.LoadScene("Map");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void QuitGame()
    {
        Application.Quit();    
    }

} 
