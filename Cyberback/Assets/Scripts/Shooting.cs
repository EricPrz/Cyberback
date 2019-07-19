using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 0649
public class Shooting : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private Controller controller;

    public Camera fpsCam;


    private void Update()
    {
        if (controller.StartShoot())
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
