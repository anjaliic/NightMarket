using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public bool itemHover;
    public GameObject item;

    public bool touching;

    public Sprite openMouth;
    public Sprite closeMouth;

    SpriteRenderer spRend;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(itemHover == true)
        {
            spRend.sprite = openMouth;
        }
        else
        {
            spRend.sprite = closeMouth;
        }

        if (Input.touchCount > 0)
        {
            touching = true;
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Ended && itemHover == true)
            {
                item.transform.position = item.GetComponent<Draggable>().startingPos;
                itemHover = false;
                spRend.sprite = closeMouth;
            }
        }
        else
        {
            touching = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (touching == true)
        {
            item = collision.gameObject;
            itemHover = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (touching == true)
        {
            item = null;
            itemHover = false;
        }
    }
}
