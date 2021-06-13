using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone_Behaviour : MonoBehaviour
{
 
    private void OnTriggerExit2D(Collider2D other)
    {
       // Debug.Log("OOOK");
        if (other.tag == "Obstacle")
        {
           // Debug.Log("Kaboom");
            Destroy(other.gameObject);
            //other.DestroySelf();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("OOOK");
        if (other.tag == "Player")
        {
            GameManager.EndGame();
        }
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            //game_Master
        }
    }
}
