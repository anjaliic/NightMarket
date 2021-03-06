﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour
{
    public GameObject ricespread;
    public bool onRice;
    public bool cooked;

    SpriteRenderer spRend;
    public Sprite cookedMeatball;

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Fireable>().cooked == true)
        {
            spRend.sprite = cookedMeatball;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Ended)
            {
                if(onRice == true)
                {
                    ricespread.GetComponent<RiceSpread>().haveMeatball = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("ricespread"))
        {
            onRice = true;
            ricespread = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ricespread"))
        {
            onRice = false;
            ricespread = null;
        }
    }
}
