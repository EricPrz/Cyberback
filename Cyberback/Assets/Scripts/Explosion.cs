using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649
public class Explosion : MonoBehaviour
{

    [SerializeField] private GameObject ExplosionVisuals;
    [SerializeField] private float destroyTime;

    public void Explode(float radius, float maxForce)
    {
        ExplosionVisuals.SetActive(true);
        ExplosionVisuals.transform.localScale = new Vector3(radius, radius, radius);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in hitColliders)
        {

            //SEARCH FOR PLAYER COMPONENT
             // if player component exist --> Damage to player
             // if player component does not exist:
                // search for "DestroyableObject" component
                // if component exist --> Damage the object.

            Rigidbody rb = col.attachedRigidbody;

            if (rb != null)
            {
                Vector3 direction = col.ClosestPoint(transform.position) - transform.position;

                float forceToApply = maxForce / radius * direction.magnitude;

                rb.AddForce(forceToApply * direction.normalized, ForceMode.Impulse);
            }


        }

        Invoke("DestroyExplosion", destroyTime);

    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }

}
