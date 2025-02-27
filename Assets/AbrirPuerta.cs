using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public PuertaFinal puertaFinal;
    private void OnDestroy()
    {
        puertaFinal.puertasCerradas -= 1;
    }
}
