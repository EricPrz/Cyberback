using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;

    public float fireRate;
    public float damage;
    public float range;
    public bool isExplosive;
    public float radius;
    public float force;

    public override string ToString()
    {
        return weaponName;
    }

}
