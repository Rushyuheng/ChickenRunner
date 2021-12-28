using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertest : MonoBehaviour
{
    [SerializeField] Vector3 Direction = new Vector3(0, 0, 0);
    [SerializeField] float movingSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Direction = Vector3.forward;
            transform.localPosition += movingSpeed * Time.deltaTime * Direction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction = Vector3.back;
            transform.localPosition += movingSpeed * Time.deltaTime * Direction;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction = Vector3.right;
            transform.localPosition += movingSpeed * Time.deltaTime * Direction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction = Vector3.left;
            transform.localPosition += movingSpeed * Time.deltaTime * Direction;
        }
    }
}
