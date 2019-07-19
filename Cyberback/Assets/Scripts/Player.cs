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
    [SerializeField] private float hp;
    [SerializeField] private Text hpText;


    public float hit(float damage)
    {
        return SetHpTo(hp - damage);
    }

    public float health(float quantity)
    {
        return SetHpTo(hp + quantity);
    }

    private float SetHpTo(float newHp)
    {
        hp = newHp;
        hpText.text = newHp.ToString();
        return hp;
    }     

}
