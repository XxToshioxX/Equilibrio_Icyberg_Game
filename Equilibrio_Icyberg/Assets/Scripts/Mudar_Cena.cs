using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mudar_Cena : MonoBehaviour
{
    public string CarregarCena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cena()
    {
        SceneManager.LoadScene(CarregarCena);
    }
}
