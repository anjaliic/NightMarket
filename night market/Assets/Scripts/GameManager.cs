using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public string currentScreen;
    Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        currentScreen = "prep";
    }

    // Update is called once per frame
    void Update()
    {
        //currentScreen = GameMng.gameObject.GetComponent<GameManager>().currentScreen;

        if (cam.transform.position.x < 0)
        {
            currentScreen = "food";
        }
        else if(cam.transform.position.x > 0)
        {
            currentScreen = "pantry";
        }
        else if(cam.transform.position.x == 0)
        {
            currentScreen = "prep";
        }
    }
}
