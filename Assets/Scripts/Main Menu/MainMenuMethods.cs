using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMethods : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void newGame()
    {
        SceneManager.LoadScene(1);
    }
    public void settings()
    {
        SceneManager.LoadScene(3);
    }
    public void credits()
    {
        SceneManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
}
