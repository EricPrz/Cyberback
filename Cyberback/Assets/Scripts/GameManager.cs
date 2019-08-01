using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class GameManager : MonoBehaviour
{


    [SerializeField] private GameObject[] spawns;
    

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("S'han creat dos objectes GameManagers, només n'hi hauria d'haver un.");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void Respawn(GameObject respawnObject)
    {
        //int RandomSpawn = Random.Range(0, spawns.Length - 1);
        //Debug.Log("Choosen spawn: " + RandomSpawn + ". Spawn posposition = " + spawns[RandomSpawn].transform.position, spawns[RandomSpawn]);

        CharacterController charController = respawnObject.GetComponent<CharacterController>();

        if (charController != null)
            charController.enabled = false;

        respawnObject.transform.position = spawns[Random.Range(0, spawns.Length - 1)].transform.position;

        if (charController != null)
            charController.enabled = true;

        //Debug.Log("Respawn object position = " + respawnObject.transform.position, respawnObject);

    }

    public bool NotifyScore(Player player, int score)
    {
        /*if (score >= WinScore)
        {
            Debug.Log(player.gameObject.name + " wins!");
            //TODO: Stop game or reset game
            return true;
        }*/
        
        return false;
    }




}
