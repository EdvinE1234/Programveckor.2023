using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameMenu;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // koden för pausmenyn. - hugo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            _gameMenu.SetActive(true);


        }
    }


    public void ResumeButton()
    {
        Time.timeScale = 1f;
        _gameMenu.SetActive(false);
        
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

