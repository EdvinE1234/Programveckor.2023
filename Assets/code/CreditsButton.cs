using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public bool isCredits;
    

    public void PlayGame()
    {
        if (isCredits)
        {
            SceneManager.LoadScene(3);

        }
        
    }
}