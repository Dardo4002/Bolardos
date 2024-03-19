using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image powerbar;
    public Image angle;
    public BallControler ballControler;
    public TMPro.TextMeshPro puntos;
    public string puntuacion = "0";
    static UIManager instance;
    
    public static UIManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        ActualizaFuerza();
        ActualizaAngulo();
        puntos.text = puntuacion;
    }

    void ActualizaFuerza()
    {
        powerbar.fillAmount = ballControler.fuerza / ballControler.max_fuerza;
    }

    void ActualizaAngulo()
    {
        if (ballControler.angulo < 0)
        {
            angle.fillAmount = - ballControler.angulo / ballControler.max_angulo;
        }
        else
        {
            angle.fillAmount = ballControler.angulo / ballControler.max_angulo;
        }
        
    }

    public void ActualizarPuntos()
    {
        puntuacion += 1;
    }
}
