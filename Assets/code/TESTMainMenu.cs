using UnityEngine;
using UnityEngine.UI;

public class TESTMainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        startMenu.SetActive(false);
        // Start the game here
    }
}

