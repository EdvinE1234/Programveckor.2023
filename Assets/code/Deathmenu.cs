using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _Deathmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //kollar vilken scen du är i, och loadar den scenen när du trycker på restart. (Philip)
    }
    public void menubutton()
    {
        SceneManager.LoadScene(0);
    }
}
