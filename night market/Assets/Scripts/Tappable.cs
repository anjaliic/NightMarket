using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappable : MonoBehaviour
{
    Collider2D col;

    public bool tapped;
    public bool tappable;

    void Start()
    {
        tappable = true;
        col = GetComponent<Collider2D>();
    }
   
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if (touch.phase == TouchPhase.Began && col == touchedCollider)
            {
                if (tappable == true)
                {
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => tapped = true;
                }
            } 
        }
    }
}
