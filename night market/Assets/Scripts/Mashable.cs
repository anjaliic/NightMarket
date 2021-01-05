using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashable : MonoBehaviour
{
    //this ingredient can be mashed with the mallet
    
    public bool mashed;

    public int mashesNeeded;
    public int mashCount;
    public int temp;

    public bool malletHover;
    public Collider2D malletDetection;

    void Start()
    {
        malletDetection = GameObject.Find("malletDetection").GetComponent<Collider2D>();
    }

    void Update()
    {
        if(malletHover == true)
        {
           if(temp < _Tracker.Instance.taps)
            {
                mashCount++;
                temp = _Tracker.Instance.taps;
            }
        }
        if(mashCount == mashesNeeded)
        {
            mashed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == malletDetection)
        {
            malletHover = true;
            temp = _Tracker.Instance.taps;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == malletDetection)
        {
            malletHover = false;
        }
    }
}
