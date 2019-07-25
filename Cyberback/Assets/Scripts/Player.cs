﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class Player : MonoBehaviour
{

    [SerializeField] public Controller controller;
    //[SerializeField] public float damage;
    //[SerializeField] public float range;
    private float currentHp;
    [SerializeField] private float maxHp;
    [SerializeField] private Text hpText;

    private float shield;

    [SerializeField] private float timeToHeal;
    private float timeRemainingToHeal;
    [SerializeField] private float healingPerSecond;

    [SerializeField] private Weapon[] weapons;
    [HideInInspector] public Weapon currentWeapon;
    [HideInInspector] private int currentWeaponNumnber;
    [SerializeField] private Text weaponText;


    void Start()
    {
        currentHp = maxHp;
        SetCurrentWeapon(0);
    }

    public float Hit(float damage)
    {
        if (shield >= damage)
        {
            hitShield(damage);
            return 0;
        }
        else if (shield > 0 && shield < damage)
        {
            damage = damage - shield;
            hitShield(shield);
        }

        timeRemainingToHeal = timeToHeal;
        return SetHpTo(currentHp - damage);
    }

    private void hitShield(float damage)
    {
        shield -= damage;
        UpdateHealthVisuals();
    }

    public float Heal(float quantity)
    {
        return SetHpTo(currentHp + quantity);
    }

    private float SetHpTo(float newHp)
    {
        currentHp = Mathf.Clamp(newHp, 0f, maxHp);
        UpdateHealthVisuals();
        return currentHp;
    }

    private void UpdateHealthVisuals()
    {
        hpText.text = Mathf.Round(currentHp).ToString() + " / " + Mathf.Round(shield).ToString();
    }

    private void Update()
    {
        timeRemainingToHeal -= Time.deltaTime;

        if (currentHp < maxHp)
            if (timeRemainingToHeal <= 0)
                Heal(healingPerSecond * Time.deltaTime);


        if (controller.IsSwapingWeapon())
        {
            int newweaponnumber = currentWeaponNumnber + 1;
            if (newweaponnumber > weapons.Length - 1)
                newweaponnumber = 0;

            SetCurrentWeapon(newweaponnumber);
        }
    }

    private void SetCurrentWeapon(int weaponNumber)
    {
        currentWeaponNumnber = weaponNumber;
        currentWeapon = weapons[currentWeaponNumnber];
        weaponText.text = currentWeapon.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        Shield shield = other.gameObject.GetComponent<Shield>();

        if (shield == null)
            return;

        if (ApplyShield(shield.ammount))
            Destroy(shield.gameObject);
    }

    private bool ApplyShield(float ammount)
    {
        if (shield >= ammount)
            return false;

        shield = ammount;
        UpdateHealthVisuals();
        return true;
    }
}