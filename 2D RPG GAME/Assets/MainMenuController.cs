using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioSource playerSource;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MuteSound()
    {
        playerSource.mute = !playerSource.mute;
    }
}
