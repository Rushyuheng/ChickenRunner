using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
public class gameManager : MonoBehaviour
{
    public float counter;
    [SerializeField] BoxCollider box;
    public int player1_lap;
    public int player2_lap;
    public static gameManager inst;
    public bool gameGoing = false;

    public Image one, two;
    public GameObject gameoverUI;

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
        gameoverUI.SetActive(false);
    }

    private void CheckWinner() {
        if (player1_lap > 3 && gameGoing) {
            PlayerWin(1);
            gameGoing = false;
        }
        else if (player2_lap > 3 && gameGoing) {
            PlayerWin(2);
            gameGoing = false;
        }
    }

    public void PlayerWin(int playerIndex)
    {
        gameoverUI.SetActive(true);
        
        if (playerIndex == 1)
        {
            two.enabled = false;
        }
        else if (playerIndex == 2)
        {
            one.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 3f)
        {
            counter += Time.deltaTime;
        }
        else if(counter >= 3f && counter <= 4f){ // set to call only once to avoid overhead
            box.isTrigger = true;
            gameGoing = true;
        }
        CheckWinner();
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
