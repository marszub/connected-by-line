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

    public void NewGameButton()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene(GameManager.instance.gameSceneName, LoadSceneMode.Single);
    }

    void Display()
    {
        animator.SetTrigger("FadeIn");
        result.text = GameManager.instance.score.ToString() + " Points!";
    }
    private void OnDestroy()
    {
        GameManager.stop -= Display;
    }
}
