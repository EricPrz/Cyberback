using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveObject : MonoBehaviour
{

    [SerializeField] private float maxHP;
    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void Hit (float damage)
    {
        currentHP = currentHP - damage;

        if (currentHP <= 0)
            Destroy(gameObject);

    }
}
