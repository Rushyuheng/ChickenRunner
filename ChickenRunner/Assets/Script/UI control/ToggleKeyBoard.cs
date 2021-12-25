using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleKeyBoard : MonoBehaviour,IPointerClickHandler
{

    public Image keyboard;

    public void OnPointerClick(PointerEventData eventData)
    {
        //toggle on/off 
        keyboard.enabled = !keyboard.enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        keyboard.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
