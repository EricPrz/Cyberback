using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class Player : MonoBehaviour
{

    [SerializeField] public Controller controller;
    [SerializeField] public float damage;
    [SerializeField] public float range;
    private float currentHp;
    [SerializeField] private float maxHp;
    [SerializeField] private Text hpText;

    [SerializeField] private float timeToHeal;
    private float timeRemainingToHeal;
    [SerializeField] private float healingPerSecond;


    void Start()
    {
        currentHp = maxHp;
    }

    public float Hit(float damage)
    {
        timeRemainingToHeal = timeToHeal;
        return SetHpTo(currentHp - damage);
    }

    public float Heal(float quantity)
    {
        return SetHpTo(currentHp + quantity);
    }

    private float SetHpTo(float newHp)
    {
        currentHp = Mathf.Clamp( newHp, 0f, maxHp );
        hpText.text = currentHp.ToString();
        return currentHp;
    }    
    
    private void Update()
    {
        timeRemainingToHeal -= Time.deltaTime;

        if(currentHp < maxHp)
            if (timeRemainingToHeal <= 0)
                Heal(healingPerSecond * Time.deltaTime);
    }

}
