using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chest;
    private float targetTime = 45.0f;
    const float spawnDuration = 45.0f;

    private void SpawnChest() {
        GameObject concreteChest = Instantiate(chest);
        concreteChest.transform.parent = transform;
        concreteChest.transform.localPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnChest();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0) {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                targetTime = spawnDuration;
                SpawnChest();

            }
        }
    }
}
