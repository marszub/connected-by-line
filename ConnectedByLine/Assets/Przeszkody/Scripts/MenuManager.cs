using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Game");
        }
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown("c"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
