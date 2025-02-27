using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    private TextMeshProUGUI indicadorVida;

    public float vidaMaxima = 100;
    public float vidaActual;

    public Transform posicionRespawn;
    public GameObject jugador;


    void Start()
    {
        indicadorVida = GetComponent<TextMeshProUGUI>();
        indicadorVida.text = "" + vidaMaxima;

        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(float dañoRecibido)
    {
        vidaActual -= dañoRecibido;
    }

    private void Update()
    {
        indicadorVida.text = "" + vidaActual;

        if (vidaActual < 0)
        {
            Respawn(); 
        }
    }

    public void Respawn()
    {
        jugador.transform.position = posicionRespawn.position;
        vidaActual = vidaMaxima;
    }
}
