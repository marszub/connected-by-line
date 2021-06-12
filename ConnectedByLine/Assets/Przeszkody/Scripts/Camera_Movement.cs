using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    
    public float cameraVelocity = 5;

    private Rigidbody2D cameraman;

    // Start is called before the first frame update
    void Start()
    {
        
        cameraman = GetComponent<Rigidbody2D>();
        cameraman.velocity = new Vector2(cameraVelocity, 0);
        //GameManager.stop += Stop;
    }


    // Update is called once per frame
    void Stop()
    {
        cameraman.velocity = new Vector2(0, 0);
    }

    void OnDestroy()
    {
        //GameManager.stop -= Stop;
    }
}
