using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    private Rigidbody rb;
    //godmode
    public float force_up = 10;
    public float force_2D;
    public float force_position = 5;

    //int
    [SerializeField] int ronda = 1;

    //float
    public float reload = 10;
    [SerializeField] public float fuerza = 0;
    public float max_fuerza = 10;
    [SerializeField] float multiplicador_fuerza = 10;
    [SerializeField] public float angulo = -10;
    public float max_angulo = 10;
    public float min_angulo = -10;
    [SerializeField] float multiplicador_angulo = 4;

    //bool
    [SerializeField] private bool god_mode = false;
    public bool choque = false;
    public bool tirada = true;
    public bool angulo_establecido = false;
    public bool fuerza_establecida = false;
    public bool posicion_establecida = false;

    //lo de abajo era para colocar los bolos en el inicio
    static public bool colocar_bolos = false;
    bool check_fuerza = false;
    bool check_angulo = false;
    [SerializeField] public bool jugable = true;

    //vector
    private Vector3 posicion_inicial = new Vector3(0, 0.59f, -5);


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (jugable == true)
        {
            if (god_mode == false)
            {
                if (posicion_establecida == false)
                {
                    DecisionPosicion();
                }
                if (posicion_establecida == true)
                    rb.freezeRotation = false;
                if (angulo_establecido == false)
                {
                    DecisionAngulo();
                }
                if (fuerza_establecida == false)
                {
                    DecisionFuerza();
                }
                VolverTirar();
            }

            if (god_mode == true)
            {
                FuerzaAlanteGod();
                FuerzaArriba();
                FuerzaAtras();
                FuerzaDerecha();
                FuerzaIzquierda();
            }
        }
    }

    void DecisionPosicion()
    {
        rb.freezeRotation = true;
        if (Input.GetKey("a"))
            rb.AddForce(Vector3.left * force_position, ForceMode.VelocityChange);
        else
            rb.velocity = Vector3.zero;
        if (Input.GetKey("d"))
            rb.AddForce(Vector3.right * force_position, ForceMode.VelocityChange);
        else
            rb.velocity = Vector3.zero;
    }

    void DecisionAngulo()
    {
        if (tirada == true)
        {
            if (check_angulo == false)
            {
                angulo += Time.deltaTime * multiplicador_angulo;
                if (angulo > max_angulo)
                    check_angulo = true;
            }
            if (check_angulo == true)
            {
                angulo -= Time.deltaTime * multiplicador_angulo;
                if (angulo < min_angulo)
                check_angulo = false;
            }

            if (Input.GetKeyDown("s"))
            {
                this.transform.Rotate(new Vector3(0f, angulo, 0f));
                angulo_establecido = true;
                posicion_establecida = true;
            }
        }
    }

    void DecisionFuerza()
    {
        

        if (tirada == true)
        {
            if (check_fuerza == false)
            {
                fuerza += Time.deltaTime * multiplicador_fuerza;
                if (fuerza > max_fuerza)
                    check_fuerza = true;
            }
            if (check_fuerza == true)
            {
                fuerza -= Time.deltaTime * multiplicador_fuerza;
                if (fuerza < 0)
                    check_fuerza = false;
            }          

            if (Input.GetKeyDown("w"))
            {
                force_2D = fuerza * 10;
                rb.AddForce(transform.forward * force_2D, ForceMode.Impulse);
                choque = true;
                tirada = false;
                fuerza_establecida = true;
                posicion_establecida = true;
                ronda++;
            }
        }
    }

    void VolverTirar()
    {
        if (choque == true)
        {
            reload -= Time.deltaTime;
        }
        
        if (reload <= 0)
        {
            reload = 10;
            choque = false;
            tirada = true;
            colocar_bolos = true;
            PosicionInicial();
        }
    }

    void PosicionInicial()
    {
        fuerza = 0;
        angulo = 0;
        rb.isKinematic = true;
        transform.position = posicion_inicial;
        transform.rotation = Quaternion.identity;
        rb.isKinematic = false;
        fuerza_establecida = false;
        angulo_establecido = false;
        posicion_establecida = false;
        colocar_bolos = false;
        Final();
    }

    void Final()
    {
        if (ronda == 3)
        {
            jugable = false;
        }
    }

    //god mode
    void FuerzaArriba()
    {
        if (Input.GetKeyDown("space"))
            rb.AddForce(Vector3.up * force_up, ForceMode.Impulse);
    }

    void FuerzaAlanteGod()
    {
        if (Input.GetKeyDown("w"))
            rb.AddForce(Vector3.forward * force_2D, ForceMode.Impulse);
    }

    void FuerzaAtras()
    {
        if (Input.GetKeyDown("s"))
            rb.AddForce(Vector3.back * force_2D, ForceMode.Impulse);
    }

    void FuerzaIzquierda()
    {
        if (Input.GetKeyDown("a"))
            rb.AddForce(Vector3.left * force_2D, ForceMode.Impulse);
    }

    void FuerzaDerecha()
    {
        if (Input.GetKeyDown("d"))
            rb.AddForce(Vector3.right * force_2D, ForceMode.Impulse);
    }

    //no se como hacerlo
    void CambioGodMode()
    {
        if (Input.GetKeyDown("t") && god_mode == false)
            god_mode = true;
        else
            god_mode = false;
    }
}
