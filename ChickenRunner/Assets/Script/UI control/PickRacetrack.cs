using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PickRacetrack : MonoBehaviour,IPointerClickHandler
{
    private Button button;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (button.name.Contains("1")) {
            SceneManager.LoadScene("RaceTrack1", LoadSceneMode.Single);
        }
        else if (button.name.Contains("2")) {
            SceneManager.LoadScene("RaceTrack2", LoadSceneMode.Single);
        }
        else if (button.name.Contains("3"))
        {
            SceneManager.LoadScene("RaceTrack3", LoadSceneMode.Single);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
