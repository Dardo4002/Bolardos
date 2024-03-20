using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public bool derribado;
    private Vector3 posicion_inicial = new Vector3(0, 0.59f, -5);
    // Start is called before the first frame update
    void Start()
    {
        derribado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!derribado && ((transform.rotation.eulerAngles.x > 45 && transform.rotation.eulerAngles.x < 315) || transform.rotation.eulerAngles.z > 45 && transform.rotation.eulerAngles.z < 315))
        {
            derribado = true;
            UIManager.Instance.ActualizarPuntos();
        }
    }

    /* no funciona el reposicionamiento de los bolos --> preguntar Luis el viernes
    public void Reestablecer()
    {
        if (BallControler.colocar_bolos == true)
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.position = posicion_inicial;
        }
    }
    */
}
