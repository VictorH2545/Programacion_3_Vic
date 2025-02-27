using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerEnemigos : MonoBehaviour
{
    public GameObject enemigo;
    public int tiempoAparicion;

    void Start()
    {
        StartCoroutine(EnemigoAparece());
    }
    private IEnumerator EnemigoAparece()
    {
        Instantiate(enemigo, transform.position, transform.rotation);

        yield return new WaitForSeconds(tiempoAparicion);

        StartCoroutine(EnemigoAparece());
    }

    void Update()
    {
        
    }

}
