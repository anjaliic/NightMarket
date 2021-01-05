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

    public Transform mashedState;
    Transform tr; 


    void Start()
    {
        tr = GetComponent<Transform>();
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
            Instantiate(mashedState, new Vector3(tr.position.x, tr.position.y, tr.position.z), Quaternion.identity);
            _Tracker.Instance.ingredientCount[this.gameObject.name]--;
            _Tracker.Instance.ingredientCount[mashedState.gameObject.name]++;
            Debug.Log("old states: " + _Tracker.Instance.ingredientCount[this.gameObject.name]);
            Debug.Log("new states: " + _Tracker.Instance.ingredientCount[mashedState.gameObject.name]);
            Destroy(this.gameObject);
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
