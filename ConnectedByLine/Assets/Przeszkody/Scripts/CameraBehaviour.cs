using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject backGroundTemplate;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float halfBack;

    private GameObject back1;
    private GameObject back2;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        back1 = Instantiate(backGroundTemplate) as GameObject;
        back1.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y,0);
        halfBack = back1.GetComponent<SpriteRenderer>().bounds.extents.x;
        back2 = Instantiate(backGroundTemplate) as GameObject;
        back2.transform.position = new Vector3(mainCamera.transform.position.x+2*halfBack, mainCamera.transform.position.y, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(back1.transform.position.x+halfBack +12< mainCamera.transform.position.x)
        {
            Destroy(back1);
            back1 = Instantiate(backGroundTemplate) as GameObject;
            back1.transform.position = back2.transform.position;
            Destroy(back2);
            back2 = Instantiate(backGroundTemplate) as GameObject;
            back2.transform.position = new Vector3(back1.transform.position.x + 2 * halfBack, mainCamera.transform.position.y, 0);

        }
    }
}
