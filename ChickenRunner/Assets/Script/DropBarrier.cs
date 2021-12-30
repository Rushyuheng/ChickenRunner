using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBarrier : MonoBehaviour
{
    public GameObject barrier;

    public void Drop() {
        GameObject concreteBarrier = Instantiate(barrier);
        concreteBarrier.transform.localPosition = transform.position;

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
