using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarLlave : MonoBehaviour
{
    public int cantidadDeEnemigos = 5;

    public GameObject llave;

    // Update is called once per frame
    void Update()
    {
        if (cantidadDeEnemigos == 0)
        {
            Instantiate(llave, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
