using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


#pragma warning disable 0649
[RequireComponent(typeof(Camera))]
public class Shooting : MonoBehaviour
{

    [SerializeField] private Player player;

    [SerializeField] private GameObject explosionPrefab;
    //[SerializeField] private float fireRate;

    private float timeToNextFire = 0;
    private Camera fpsCam;
    


    private void Start()
    {
        fpsCam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (player.controller.IsShooting() && Time.time >= timeToNextFire)
        {
            timeToNextFire = Time.time + player.currentWeapon.fireRate;
            Shoot();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, player.currentWeapon.range))
        {

            if (player.currentWeapon.isExplosive)
                Instantiate(explosionPrefab, hit.point, Quaternion.identity).GetComponent<Explosion>().Explode(player.currentWeapon.radius, player.currentWeapon.force, GetCurrentDamage() );
            else
            {
                Player playerHit = hit.transform.gameObject.GetComponent<Player>();

                if (playerHit != null)
                {
                    if (playerHit.Hit(GetCurrentDamage()) <= 0)
                    {
                        //Other player dead

                        player.RegisterKill();
                    }
                }
            }
          

        }
    }

    private float GetCurrentDamage()
    {
        return (player.currentWeapon.damage * (1 + ((player.maxHp - player.currentHp) * 1 / player.maxHp)));
    }







    

}
