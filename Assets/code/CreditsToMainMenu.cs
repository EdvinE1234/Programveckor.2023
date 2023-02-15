using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMainMenu : MonoBehaviour
{
    public bool isMainMenu;


    public void PlayGame()
    {
        if (isMainMenu)
        {
            SceneManager.LoadScene(0);

        }

    }
}