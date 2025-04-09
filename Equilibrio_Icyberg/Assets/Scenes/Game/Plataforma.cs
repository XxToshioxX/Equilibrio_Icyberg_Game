using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Rigidbody rb;
    public int forcaEmX;
    public int forcaEmZ = 50;
    public float velocidadeMaximaZ = 200;
    public float anguloAlvo = 45;
    public float velocidadeDerotacao = 3;

    public GameObject Model1;
    public GameObject Model2;
    public bool Icy_Model;

    public bool controle;

    private Vector3 rotacaoAtual = new Vector3();
    Vector3 rotacaoNova = new Vector3();
   
    public float velocidade = 20;

    public float v;
        public float h;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100;
    }

    
    void FixedUpdate()
    {
        if(Icy_Model == true)
        {
            Model2.SetActive(true);
            Model1.SetActive(false);
        }
        else
        {
            Model2.SetActive(false); 
            Model1.SetActive(true);
        }
        if (controle == false)
        {
            

            if (Input.GetKey("a") == false && Input.GetKey("d") == false && Input.GetKey("w") == false && Input.GetKey("s") == false)
            {
                //RotationZero();
                v = 0;
                h = 0;
            }
            if (rb.velocity.z < velocidadeMaximaZ)
            {
                rb.AddForce(0, 0, forcaEmZ * Time.fixedDeltaTime);
            }

            if (Input.GetKey("a") == true)
            {
                h = -1;
                //RotationZPositive();
            }
            else if (Input.GetKey("d") == true)
            {
                h = 1;
                //RotationZNegative();
            }
            else { h = 0; }

            if (Input.GetKey("w") == true)
            {
                v = 1;
                //RotationXPositive();
            }
            else if (Input.GetKey("s") == true)
            {
                v = -1;
                //RotationXNegative();
            }
            else { v = 0; }

            rotacaoNova.x = v;
            rotacaoNova.z = -h;
            rotacaoNova.x *= velocidade;
            rotacaoNova.z *= velocidade;
         

            


        }
        else
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            rotacaoNova.x =v;
            rotacaoNova.z = -h;
            rotacaoNova.x *= velocidade;
            rotacaoNova.z *= velocidade;
           
            //if (h == 0 && v == 0)
            //{
            //    RotationZero();
            //}
            //if (h == 1)
            //{
            //    RotationZPositive();
            //}
            //else if (h == -1)
            //{
            //    RotationZNegative();
            //}
            //if (v == 1)
            //{
            //    RotationXPositive();
            //}
            //else if (v == -1)
            //{
            //    RotationXNegative();
            //}
        }
        rotacaoAtual = Vector3.Lerp(rotacaoAtual, rotacaoNova, Time.deltaTime * 5);
        
        transform.eulerAngles = rotacaoAtual;
    }

    //public void RotationZPositive()
    //{
    //    if (Icy_Model == false)
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, +anguloAlvo);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //    else
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-90, 0, 162.989f + anguloAlvo);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //}
    //public void RotationZNegative()
    //{
    //    if (Icy_Model == false)
    //    {
    //        rb.AddForce(forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, -anguloAlvo);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //    else
    //    {
    //        rb.AddForce(forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-90, 0, 162.989f - anguloAlvo);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //}
    //public void RotationXPositive()
    //{
    //    if (Icy_Model == false)
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(0 + anguloAlvo, 0, 0);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //    else
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-90 + anguloAlvo, 0, 162.989f);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //}
    //public void RotationXNegative()
    //{
    //    if (Icy_Model == false)
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-anguloAlvo, 0, 0);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //    else
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-90 - anguloAlvo, 0, 162.989f);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //}

    //public void RotationZero()
    //{
    //    if (Icy_Model == false)
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-0, 0, 0);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //    else
    //    {
    //        rb.AddForce(-forcaEmZ * Time.fixedDeltaTime, 0, 0);

    //        Quaternion rotacaoAtual = rb.rotation;
    //        Quaternion rotacaoAlvo = Quaternion.Euler(-90, 0, 162.989f);
    //        Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDerotacao);
    //        rb.MoveRotation(novaRotacao);
    //    }
    //}
}
