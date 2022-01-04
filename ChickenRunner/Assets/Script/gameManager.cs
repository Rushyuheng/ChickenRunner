using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class gameManager : MonoBehaviour
{
    public float counter;
    [SerializeField] BoxCollider box;
    public int player1_lap;
    public int player2_lap;
    public static gameManager inst;
    void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start() {
        player1_lap = 0;
        player2_lap = 0;
        box.isTrigger = false;
        counter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 3f)
        {
            counter += Time.deltaTime;
        }
        else {
            box.isTrigger = true;
        }
    }

    void printWinner() {//only check if lap is working
        if (player1_lap == 4)
        {
            Debug.Log("Player 1 wins!");
        }
        else if (player2_lap == 4)
        {
            Debug.Log("Player 2 wins!");
        }
    }

}
