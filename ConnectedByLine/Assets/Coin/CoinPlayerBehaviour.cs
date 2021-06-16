using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Coin") && GameManager.instance.gameState == GameState.PlayingTheGame)
        {
            GameManager.instance.UpdatePoints(1);
            Destroy(other.gameObject);
        }
    }
}
