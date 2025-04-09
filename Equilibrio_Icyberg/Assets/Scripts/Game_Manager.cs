using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public Text scoretxt;
    public float score1;
    public float score2;
    public float score3;
    
    public float score;

    public GameObject pause;
    private bool unpaused;
    
    void Start()
    {
        instance = this;
        PlayerPrefs.SetFloat("Score", 0);
        pause.SetActive(false);
        unpaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        score = score1+score2+score3;
        scoretxt.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            unpaused = !unpaused;
            Pause();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Pause()
    {
        if (unpaused == true)
        {
            Time.timeScale = 1.0f;
            pause.SetActive(false) ;
        }
        else
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
      
    }
    public void Unpaused()
    {
        unpaused = !unpaused;
        Pause();
    }
}
