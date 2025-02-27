using Profe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private TipoDePuerta tipoDePuerta;

    //Evento
    [SerializeField] public bool eventoActivado;

    // Llave
    [SerializeField] private SOItem key;

    // MultiplesLlaves
    [SerializeField] private SOItem[] keys;


    private InventoryHandler inventoryHandler;

    public Transform puertaArriba;

    public Transform puertaAbajo;

    public bool automatica;

    public PuertaFinal puertaFinal;

    private void Awake()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();
    }

    public void Interact()
    {
        switch (tipoDePuerta)
        {
            case TipoDePuerta.Automatica:
                {
                    Automatica();
                    Debug.Log("Se abre automaticamente");
                    break;
                }

            case TipoDePuerta.Normal:
                {
                    Normal();
                    Debug.Log("Se abre");
                    break;
                }

            case TipoDePuerta.DeLlave:
                {
                    DeLlave();
                    Debug.Log("Se abre con llave");
                    break;
                }

            case TipoDePuerta.Evento:
                {
                    Evento();
                    Debug.Log("Se abre con evento");
                    break;
                }

            case TipoDePuerta.MultiplesLlaves:
                {
                    MultiplesLlaves();
                    Debug.Log("Se abre con multiples llaves");
                    break;
                }
        }

        puertaFinal.puertasCerradas -= 1;
    }


    private void Automatica()
    {
        automatica = true;
    }

    private void Normal()
    {
        Destroy(gameObject);
    }

    private void Evento()
    {
        if (eventoActivado)
        {
            Destroy(gameObject);
        }
    }

    private void MultiplesLlaves()
    {
        if (inventoryHandler.inventory.Contains(keys[0]) && inventoryHandler.inventory.Contains(keys[1]))
        {
            Destroy(gameObject);
        }
    }


    private void DeLlave()
    {
        if (inventoryHandler.inventory.Contains(key))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (automatica)
        {
            transform.position = puertaArriba.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (automatica)
        {
            transform.position = puertaAbajo.position;
        }
    }

}


public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}

