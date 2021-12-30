using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1HUD : MonoBehaviour
{
    public Image speedUp;
    public Image barrier;

    public void ShowItem(int index) {
        if (index == 1)
        {
            speedUp.enabled = true;
        }
        else if (index == 2) {
            barrier.enabled = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
