using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


#pragma warning disable 0649
[RequireComponent(typeof(Camera))]
public class Shooting : MonoBehaviour
{

    [SerializeField] private Player player;
    //[SerializeField] private float fireRate;

    private float timeToNextFire = 0;
    private Camera fpsCam;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private int scorePerKill = 1;
    private int score;

    private void Start()
    {
        fpsCam = GetComponent<Camera>();

        score = 0;
    }

    private void Update()
    {
        if (player.controller.IsShooting() && Time.time >= timeToNextFire)
        {
            timeToNextFire = Time.time + player.currentWeapon.fireRate;
            Shoot();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, player.currentWeapon.range))
        {
            Player playerHit = hit.transform.gameObject.GetComponent<Player>();

            if (playerHit != null)
            {
                if (playerHit.Hit(player.currentWeapon.damage * (1 + ((player.maxHp - player.currentHp) * 1 / player.maxHp))) <= 0)
                {
                    //Other player dead

                    score += scorePerKill;
                    UpdateScoreVisuals();
                    GameManager.Instance.NotifyScore(player, score);
                }
            }

        }
    }

    private void UpdateScoreVisuals()
    {
        scoreText.text = Mathf.Round(score).ToString();
    }
}
