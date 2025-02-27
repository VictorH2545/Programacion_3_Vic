using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public int puertasCerradas = 10;

    public Door ultimaPuerta;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puertasCerradas <= 1)
        {
            ultimaPuerta.eventoActivado = true;
        }    
    }
}
