using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
