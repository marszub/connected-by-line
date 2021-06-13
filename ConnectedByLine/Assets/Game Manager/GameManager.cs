using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startHP = 3;
    public delegate void EventHandler();
    public static event EventHandler stop;
    public static GameManager instance;
    private int points;
    private int HP;
    public static int hp { get { return instance.HP; } }
    public static int score { get { return instance.points; } }
    private GameState state;

    void Start()
    {
        if (instance is null)
            instance = this;
        else
            Destroy(gameObject);
        StartGame();
    }

    public void UpdateHP(int update)
    {
        HP = HP - update;
        if(HP < 1 && state == GameState.PlayingTheGame)
            EndGame();
    }

    public static void UpdatePoints(int points)
    {
        instance.points += points;
    }

    public static void EndGame()
    {
        instance.state = GameState.Lose;
        stop?.Invoke();
    }

    private void StartGame()
    {
        if(state == GameState.Lose)
        {
            state = GameState.PlayingTheGame;
            HP = startHP;
            points = 0;
            Debug.Log("AAA");
        }
    }
}
public enum GameState
{
    PlayingTheGame,
    Lose
}
