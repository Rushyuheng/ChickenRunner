using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    private PlayerHUD player1HUD,player2HUD;
    // Start is called before the first frame update
    void Start()
    {
        gameManager gameManager = FindObjectOfType<gameManager>();
        player1HUD = gameManager.transform.GetChild(0).gameObject.GetComponentInChildren<PlayerHUD>();
        player2HUD = gameManager.transform.GetChild(1).gameObject.GetComponentInChildren<PlayerHUD>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player1Physic")
        {
            gameManager.inst.player1_lap++;
            Debug.Log("Player 1 lap is " + gameManager.inst.player1_lap);
            // only show 1 - 3 lap
            if (gameManager.inst.player1_lap > 0 && gameManager.inst.player1_lap <= 3) {
                player1HUD.ShowLap(gameManager.inst.player1_lap);
            }
        }
        else if (other.gameObject.name == "Player2Physic")
        {
            gameManager.inst.player2_lap++;
            Debug.Log("Player 2 lap is " + gameManager.inst.player2_lap);
            if (gameManager.inst.player2_lap > 0 && gameManager.inst.player2_lap <= 3)
            {
                player2HUD.ShowLap(gameManager.inst.player2_lap);
            }
        }
    }
    
}
