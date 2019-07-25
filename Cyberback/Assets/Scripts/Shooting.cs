﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 0649
public class Shooting : MonoBehaviour
{

    [SerializeField] private Player player;
    //[SerializeField] private float fireRate;

    private float nextFire = 0;
    private Camera fpsCam;
    
    private void Start()
    {
        fpsCam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (player.controller.IsShooting() && Time.time >= nextFire)
        {
            nextFire = Time.time + player.currentWeapon.fireRate;
            Shoot();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, player.currentWeapon.range))
        {
            Player playerHit = hit.transform.gameObject.GetComponent<Player>();

            if (playerHit != null)
            {
                playerHit.Hit(player.currentWeapon.damage * (1 + ((player.maxHp - player.currentHp) * 1 / player.maxHp)));
            }

        }
    }
}
