using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public bool derribado;
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
}
