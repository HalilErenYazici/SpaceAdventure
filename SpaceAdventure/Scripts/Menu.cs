using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu, credistMenu;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        credistMenu.SetActive(true);
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credistMenu.SetActive(false);
    }
}
