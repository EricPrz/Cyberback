using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#pragma warning disable 0649
public class Explosion : MonoBehaviour
{   
    [SerializeField] private GameObject ExplosionVisuals;
    [SerializeField] private float destroyTime;
           
    private float explosionDamage;

    public void Explode(float radius, float maxForce, float maxDamage)
    {
        ExplosionVisuals.SetActive(true);
        ExplosionVisuals.transform.localScale = new Vector3(radius, radius, radius);

        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, radius).ToList();

        //REMOVE DUPLICATES =====
        List<GameObject> gameObjectsWithColliders = new List<GameObject>();
        List<Collider> collidersToDelete = new List<Collider>();
        foreach (Collider colToCheck in hitColliders)
        {
            if (gameObjectsWithColliders.Contains(colToCheck.gameObject))
                collidersToDelete.Add(colToCheck);
            else
                gameObjectsWithColliders.Add(colToCheck.gameObject);
        }
        foreach (Collider colToDelete in collidersToDelete)
        {
            hitColliders.Remove(colToDelete);
        }
        //======

        foreach (Collider col in hitColliders)
        {
            Vector3 direction = col.ClosestPoint(transform.position) - transform.position;

            Debug.DrawRay(transform.position, direction, Color.green, 5, true);

            Player player = col.GetComponent<Player>();
            if (player != null)
            {
                float proportionalDamage = maxDamage - (maxDamage / radius * direction.magnitude);
                Debug.DrawRay(transform.position, direction, Color.blue, 5, true);
                player.Hit(proportionalDamage);                
            }     
            
            //SEARCH FOR PLAYER COMPONENT
            // if player component exist --> Damage to player
            // if player component does not exist:
            // search for "DestroyableObject" component
            // if component exist --> Damage the object.
            
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null)
            {
                float proportionalForce = maxForce - (maxForce / radius * direction.magnitude);
                rb.AddForce(proportionalForce * direction.normalized, ForceMode.Impulse);                              
            }
        }

        Invoke("DestroyExplosion", destroyTime);

    }

    private void isPlayerExplosive()
    {
        throw new NotImplementedException();
    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }

}
