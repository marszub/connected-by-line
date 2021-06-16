using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_gen : MonoBehaviour
{

    public GameObject obstacleTemplate;
    public GameObject coinTemplate;

    public List<GameObject> patterns;

    public GameObject background;

    private float backSize = 0;
    //public AllPatterns patternsDB;

    private RectTransform rt;
    private float nextPatternTrigger =0;
    //private List<PatternColumns> pattern;
    // Start is called before the first frame update
    void Start()
    {
        //if (obstacleTemplate == null)
        //    obstacleTemplate = GameObject.FindWithTag("Obstacle");
        //if (coinTemplate == null)
        //{
          //  coinTemplate = GameObject.FindWithTag("Coin");
        //}
        
        rt = (RectTransform)gameObject.transform;
        //Instantiate(obstacleTemplate,
        //     gameObject.transform.position + new Vector3(0, (float)(1 * gameObject.transform.localScale.y), 0)
        // + new Vector3(0, (float)(0.5 * obstacleTemplate.transform.localScale.y), 0),
        //   gameObject.transform.rotation);

        backSize = 2*background.GetComponent<SpriteRenderer>().bounds.extents.x;

        //GetRandomPattern();


    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(obstacleTemplate, gameObject.transform.position + new Vector3(0, (float)(0.5 * gameObject.transform.localScale.y), 0) + new Vector3(0, (float)(0.5 * obstacleTemplate.transform.localScale.y), 0), gameObject.transform.rotation);
        if(nextPatternTrigger+10<gameObject.transform.position.x)
        {
            GenNextPattern();
        }
        
    }

    private GameObject GetRandomPattern()
    {
        int numb = patterns.Count;
        int randInd = Random.Range(0, numb);
        return patterns[randInd];
    }

    private void GenNextPattern()
    {
        GameObject patt = GetRandomPattern();


        Instantiate(patt, gameObject.transform.position , gameObject.transform.rotation);
        nextPatternTrigger += backSize;

    }
}
