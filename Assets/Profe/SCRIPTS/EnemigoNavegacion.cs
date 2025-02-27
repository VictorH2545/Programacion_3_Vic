using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoNavegacion : MonoBehaviour
{
    private NavMeshAgent fantasmaAgent;
    private GameObject jugador;
    public float fantasmaCorriendo; 

    void Start()
    {
        fantasmaAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject jugador = GameObject.Find("Jugador");
        fantasmaAgent.destination = jugador.transform.position;
    }
}
