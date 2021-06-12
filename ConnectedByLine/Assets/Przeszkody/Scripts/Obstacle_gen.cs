using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_gen : MonoBehaviour
{

    public GameObject obstacleTemplate;
    public GameObject coinTemplate;
    

    public AllPatterns patternsDB;

    private RectTransform rt;
    private float nextPatternTrigger;
    private List<PatternColumns> pattern;
    private int patternsUsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (obstacleTemplate == null)
            obstacleTemplate = GameObject.FindWithTag("Obstacle");
        if (coinTemplate == null)
        {
            coinTemplate = GameObject.FindWithTag("Coin");
        }
        
        rt = (RectTransform)gameObject.transform;
        //Instantiate(obstacleTemplate,
        //     gameObject.transform.position + new Vector3(0, (float)(1 * gameObject.transform.localScale.y), 0)
        // + new Vector3(0, (float)(0.5 * obstacleTemplate.transform.localScale.y), 0),
        //   gameObject.transform.rotation);
        GetRandomPattern();


    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(obstacleTemplate, gameObject.transform.position + new Vector3(0, (float)(0.5 * gameObject.transform.localScale.y), 0) + new Vector3(0, (float)(0.5 * obstacleTemplate.transform.localScale.y), 0), gameObject.transform.rotation);
        if(nextPatternTrigger<gameObject.transform.position.x)
        {
            if(patternsUsed == pattern.Count-1)
            {
                patternsUsed = 0;
                GetRandomPattern();
                
                
            }
            GenNextColumn();
        }
        
    }

    private void GetRandomPattern()
    {
        pattern = patternsDB.GiveRand();
    }

    private void GenNextColumn()
    {
        for(int i =0;i<pattern[patternsUsed].pat_type.Count; i++)
        {
            if(pattern[patternsUsed].pat_type[i]=="o")
            {
                Instantiate(obstacleTemplate,
                    gameObject.transform.position + new Vector3(pattern[patternsUsed].pat_vec[i].x, (float)(pattern[patternsUsed].pat_vec[i].y * gameObject.transform.localScale.y), 0)
                    + new Vector3(0, (float)(0.5 * obstacleTemplate.transform.localScale.y), 0),
                    gameObject.transform.rotation);
            }
            if (pattern[patternsUsed].pat_type[i] == "c")
            {
                Instantiate(coinTemplate,
                    gameObject.transform.position + new Vector3(pattern[patternsUsed].pat_vec[i].x, (float)(pattern[patternsUsed].pat_vec[i].y * gameObject.transform.localScale.y), 0)
                    + new Vector3(0, (float)(0.5 * coinTemplate.transform.localScale.y), 0),
                    gameObject.transform.rotation);
            }


        }

        nextPatternTrigger += pattern[patternsUsed].width;



        patternsUsed += 1;

    }
}
