using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoExplosion : MonoBehaviour
{
    public GameObject particulas;
    public VidaJugador vidaDeJugador;

    [SerializeField] private float danio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Instantiate(particulas, transform.position, transform.rotation);

            VidaJugador vidaDeJugador = GameObject.Find("vida").GetComponent<VidaJugador>();
            vidaDeJugador.RecibirDa�o(danio);
            AudioManager.AudioInstance.Play("Explosion");

            Destroy(this.gameObject);
        }
    }
}
