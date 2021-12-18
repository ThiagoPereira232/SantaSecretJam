using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject credits;
    public GameObject mainMenu;
    public Dropdown dropdown;

    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameController.instanceGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        if(dropdown.value == 0)
        {
            gc.language = DialogueControl.idiom.eng;
        }
        else
        {
            gc.language = DialogueControl.idiom.pt;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hotel");
    }

    public void LoadTutorial()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(true);
        credits.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void LoadCredits()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(false);
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackMenu()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(false);
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
