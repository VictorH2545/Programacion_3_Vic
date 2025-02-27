using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Victor.Weapons;

public class CambiarArma : MonoBehaviour
{
    public WeaponHandlerVictor inventarioArmas;
    public GameObject pistolon;
    public GameObject pistolita;

    // Update is called once per frame
    void Update()
    {
        if (inventarioArmas.currentWeapon == inventarioArmas.weapons[0])
        {
            pistolita.gameObject.SetActive(true);

            pistolon.gameObject.SetActive(false);
        }

        if (inventarioArmas.currentWeapon == inventarioArmas.weapons[1])
        {
            pistolon.gameObject.SetActive(true);
            
            pistolita.gameObject.SetActive(false);
        }
    }
}
