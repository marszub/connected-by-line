using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
