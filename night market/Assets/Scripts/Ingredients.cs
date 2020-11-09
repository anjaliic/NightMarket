using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps track of all ingredients on the prep screen 
public class Ingredients : MonoBehaviour
{
    public static Ingredients Instance { get; private set; }

    public int meatCount;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "meat")
        {
            meatCount++;
        }
    }
}
