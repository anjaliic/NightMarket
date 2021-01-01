﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mMix : MonoBehaviour
{
    public List<GameObject> mixables;

    public string activeMix;
    public int mixesNeeded;
    public int itemsNeeded;
    public int mixCount;
    public bool mixed;

    public Transform mashedmeat;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0 && _GameManager.Instance.currentScreen == "prep" && mixed == false)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("moving");
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(touchedCollider.tag == "mixable")
                {
                    Debug.Log("touched mixable");
                    //if the gameobject is already in the list, dont add
                    if (mixables.Contains(touchedCollider.gameObject)){}
                    else if(mixables.Count > 0 && touchedCollider.gameObject.name == activeMix)
                    {
                        mixables.Add(touchedCollider.gameObject);
                    }
                    else
                    {
                        mixables.Add(touchedCollider.gameObject);
                        activeMix = mixables[0].name;
                    }                 
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                if (mixed == false)
                {
                    mixables.Clear();
                }
            }
        }

        if (mixed == true)
        {
            Instantiate(mashedmeat, FindCenterPoint(), Quaternion.identity);
            foreach(GameObject item in mixables)
            {
                Destroy(item);
            }
            mixCount = 0;
            mixed = false;
            mixables.Clear();
        }

        if (mixables.Count == itemsNeeded && mixed == false)
        {
            int temp = mixesNeeded - mixCount;
            foreach(GameObject item in mixables)
            {
                item.transform.position = new Vector3((item.transform.position.x + ((FindCenterPoint().x - item.transform.position.x) / temp)), 
                    (item.transform.position.y + ((FindCenterPoint().y - item.transform.position.y) / temp)), item.transform.position.z);
            }
            mixCount++;
            if(mixCount == mixesNeeded)
            {
                mixed = true;
            }
            else
            {
                mixables.Clear();
            }
        }

    }

   Vector3 FindCenterPoint()
    {
        float xpos = 0;
        float ypos = 0;
        foreach (GameObject item in mixables)
        {
            xpos = (xpos + item.transform.position.x);
            ypos = (ypos + item.transform.position.y);
        }
        xpos = xpos / itemsNeeded;
        ypos = ypos / itemsNeeded;

        return new Vector3(xpos, ypos, mixables[0].transform.position.z);
    }
}
