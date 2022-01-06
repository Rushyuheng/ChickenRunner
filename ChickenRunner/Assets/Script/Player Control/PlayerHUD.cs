using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Image speedUp;
    private Image barrier;
    private Image[] laps = new Image[3];

    public void ShowItem(int index) {
        if (index == 0) {
            HideItem();
        }
        else if (index == 1)
        {
            speedUp.enabled = true;
        }
        else if (index == 2) {
            barrier.enabled = true;
        }

    }

    private void HideItem() {
        speedUp.enabled = false;
        barrier.enabled = false;
    }

    public void ShowLap(int lapNum) {
        for (int i = 0; i < 3; ++i) {
            laps[i].enabled = false;
        }
        laps[lapNum - 1].enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        speedUp = this.gameObject.GetComponentsInChildren<Image>()[1];
        barrier = this.gameObject.GetComponentsInChildren<Image>()[2];

        laps[0] = this.gameObject.GetComponentsInChildren<Image>()[7];
        laps[1] = this.gameObject.GetComponentsInChildren<Image>()[6];
        laps[2] = this.gameObject.GetComponentsInChildren<Image>()[5];
        ShowLap(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
