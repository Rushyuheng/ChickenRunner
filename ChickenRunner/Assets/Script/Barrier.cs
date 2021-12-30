using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10.0f); //despawn after 10 sec 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
