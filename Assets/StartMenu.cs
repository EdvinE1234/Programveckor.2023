using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    
    public void PlayGame()
    {
        if(isStart)
        {
            SceneManager.LoadScene(1);  
            
        }
        if(isQuit)
        {
            Application.Quit();
        }
    }
}
