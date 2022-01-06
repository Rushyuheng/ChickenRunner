using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image one, two;
    public void PlayerWin(int playerIndex) {
        this.enabled = true;
        if (playerIndex == 1)
        {
            two.enabled = false;
        }
        else if (playerIndex == 2) {
            one.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
