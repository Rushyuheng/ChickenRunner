using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private PlayerControl1 player1;
    private PlayerControl2 player2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("Player"))
        {
            Destroy(gameObject, 0.01f);
            if (other.gameObject.name.Contains("1"))
            {
                player1.GetItem();
            }
            else if (other.gameObject.name.Contains("2")) {
                player2.GetItem();
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindObjectOfType<PlayerControl1>();
        player2 = GameObject.FindObjectOfType<PlayerControl2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
