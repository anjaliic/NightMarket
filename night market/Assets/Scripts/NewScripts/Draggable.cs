using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Transform tr;
    Collider2D col;

    void Start()
    {
        tr = GetComponent<Transform>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        //drag & drop
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    transform.position = new Vector3(touchPosition.x, touchPosition.y, tr.position.z);
                }
            }
        }
    }
}
