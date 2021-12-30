using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Image speedUp;
    private Image barrier;

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
    // Start is called before the first frame update
    void Start()
    {
        speedUp = this.gameObject.GetComponentsInChildren<Image>()[1];
        barrier = this.gameObject.GetComponentsInChildren<Image>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
