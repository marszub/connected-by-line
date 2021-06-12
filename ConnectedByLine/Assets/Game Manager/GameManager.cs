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
    private GameState state;

    void Start()
    {
        instance = this;
        instance.StartGame();
    }
    
    public int GetHP()
    {
        return HP;
    }

    public void UpdateHP(int update)
    {
        HP = HP - update;
        if(HP < 1 && state == GameState.PlayingTheGame)
        {
            state = GameState.Lose;
            stop?.Invoke();
        }
    }

    public void UpdatePoints(int points)
    {
        this.points += points;
    }

    public int GetPoints()
    {
        return points;
    }

    private void StartGame()
    {
        if(state == GameState.Lose)
        {
            state = GameState.PlayingTheGame;
            HP = startHP;
            points = 100;
            Debug.Log("AAA");
        }
    }
}
public enum GameState
{
    PlayingTheGame,
    Lose
}
