using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMethods : MonoBehaviour
{
    [SerializeField] private Canvas main_menu_canvas;
    [SerializeField] private Canvas settings_menu_canvas;
    [SerializeField] private Canvas credit_canvas;

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
        //SceneManager.LoadScene(3);

    }
    public void credits()
    {
        //SceneManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
}
