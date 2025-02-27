using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// EJERCICIO
/// 
/// 
/// Realizar el funcionamiento para el disparo automatico de el rifle, pistola y escopeta.
/// El rifle debe de poder disparar automaticamente mientras se mantiene presionado el click izquierdo de el mouse
/// La escopeta y pistola deben de poder disparar 1 vez por click
/// 
/// </summary>
namespace Victor.Weapons
{
    /// <summary>
    /// Este script nos maneja el uso de armas
    /// Controla el inventario de armas
    /// Selecciona cual es el arma que quieres equipar
    /// Y ajusta sus funciones/controles según el arma equipada
    /// </summary>
    public class WeaponHandlerVictor : MonoBehaviour
    {

        public Weapon[] weapons;
        public Weapon currentWeapon;

        private void Update()
        {
            Aim();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentWeapon = weapons[1];
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                currentWeapon = weapons[0];
            }
        }

        private void Aim()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentWeapon.Shoot();

                if (currentWeapon == weapons[0])
                {
                    AudioManager.AudioInstance.Play("Pistolita");
                }
                else if (currentWeapon == weapons[1])
                {
                    AudioManager.AudioInstance.Play("Pistolon");
                }
            }
        }

    }

}