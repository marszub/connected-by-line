using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startHP;
    public delegate void EventHandler();
    public static event EventHandler stop;

    public static GameManager instance;

    public string gameSceneName;
    private int points;
    private int HP;
    public int hp { get { return HP; } }
    public int score { get { return points; } }
    private GameState state;
    public GameState gameState { get { return state; } }

    void Start()
    {
        instance = this;
        HP = startHP;
        points = 0;
        state = GameState.PlayingTheGame;
    }

    public void UpdateHP(int update)
    {
        HP -= update;
        if(HP < 1 && state == GameState.PlayingTheGame)
            EndGame();
    }

    public void UpdatePoints(int points)
    {
        this.points += points;
    }

    public void EndGame()
    {
        state = GameState.Lose;
        stop?.Invoke();
    }

    private void Update()
    {
        if(Input.GetButton("Submit") && state == GameState.Lose)
            SceneManager.LoadScene(GameManager.instance.gameSceneName, LoadSceneMode.Single);
        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }
}
public enum GameState
{
    PlayingTheGame,
    Lose
}
