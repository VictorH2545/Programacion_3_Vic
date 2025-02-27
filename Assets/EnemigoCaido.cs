using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCaido : MonoBehaviour
{
    public MostrarLlave mostrarLlave;

    private void OnDestroy()
    {
        mostrarLlave.cantidadDeEnemigos -= 1;
    }
}
