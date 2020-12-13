using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    public static _GameManager Instance { get; private set; }

     public Camera cam;
    public string currentScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        cam = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cam.transform.position.x < 0)
        {
            currentScreen = "pantry";
        }
        else if (cam.transform.position.x > 0)
        {
            currentScreen = "equipment";
        }
        else if (cam.transform.position.x == 0)
        {
            currentScreen = "prep";
        }
    }
}
