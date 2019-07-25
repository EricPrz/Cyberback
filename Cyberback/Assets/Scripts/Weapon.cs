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

    public override string ToString()
    {
        return weaponName;
    }

}
