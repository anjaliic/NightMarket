using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappable : MonoBehaviour
{
    //this object must be tapped to be interacted with

    Collider2D col;
    Animator anim;

    public bool tappable;
    public int taps;

    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        tappable = true;
    }

    void Update()
    {
        if (Input.touchCount > 0 && _GameManager.Instance.currentScreen == "prep")
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if (touch.phase == TouchPhase.Began && col == touchedCollider)
            {         
                if (tappable == true)
                {
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => Tapped();
                }
            } 
        }

        void Tapped()
        {
            anim.SetTrigger("tap");
            taps++;
            tappable = false;
        }
    }
}
