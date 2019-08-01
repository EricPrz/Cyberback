using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
