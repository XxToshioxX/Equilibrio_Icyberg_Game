using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Clear : MonoBehaviour
{
    public float score;

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            score = score + 1;
            Game_Manager.instance.score1 = score;
        }
    }
}
