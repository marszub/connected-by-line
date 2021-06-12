using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text result;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.stop += Display;
    }

    void Update()
    {
        if(Input.GetKey("w"))
        {
            GameManager.instance.UpdateHP(10);
        }
    }

    public void NewGameButton()
    {
        //TU LOADUJE ALE NIE UMIEM
        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    void Display()
    {
        animator.SetTrigger("FadeIn");
        result.text = GameManager.instance.GetPoints().ToString() + " Points!";
    }
}
