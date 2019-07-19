﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 0649
public class Shooting : MonoBehaviour
{

    [SerializeField] private Player player;

    private Camera fpsCam;

    private void Start()
    {
        fpsCam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (player.controller.StartShoot())
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, player.range))
        {
            Player playerHit = hit.transform.gameObject.GetComponent<Player>();

            if (playerHit != null)
            {
                playerHit.hit(player.damage);
            }

        }
    }
}
