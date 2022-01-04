using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else if (other.gameObject.name == "Player2Physic")
        {
            gameManager.inst.player2_lap++;
            Debug.Log("Player 2 lap is " + gameManager.inst.player2_lap);
        }
    }
    
}
