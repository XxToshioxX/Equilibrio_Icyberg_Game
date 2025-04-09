using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pontuacao : MonoBehaviour
{
    public float score;

    public float timerscore;
    void Start()
    {
        timerscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(timerscore< 1)
        {
            timerscore += Time.deltaTime;
        }
        
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            if (timerscore >= 1)
            {
                score = score + 1 ;
                timerscore = 0;
                Game_Manager.instance.score1 = score;
            }
        }
    }
}
