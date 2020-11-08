using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool malletActive = false;
    public GameObject chopping_board;

    public Camera cam;
    public string currentScreen;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() { 
   
        if(malletActive == true)
        {
            chopping_board.SetActive(true);
        }
        else
        {
            chopping_board.SetActive(false);
        }

        if (cam.transform.position.x < 0)
        {
            currentScreen = "food";
        }
        else if (cam.transform.position.x > 0)
        {
            currentScreen = "pantry";
        }
        else if (cam.transform.position.x == 0)
        {
            currentScreen = "prep";
        }
    }
}
