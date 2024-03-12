using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image powerbar;
    public Image angle;
    public BallControler ballControler;
    
    void Start()
    {

    }


    void Update()
    {
        ActualizaFuerza();
        ActualizaAngulo();
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

    
}
