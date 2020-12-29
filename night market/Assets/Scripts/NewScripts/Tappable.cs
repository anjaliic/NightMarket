using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tappable : MonoBehaviour
{
    //this object must be tapped to be interacted with

    Collider2D col;
    Animator anim;

    public bool tappable = true;
    public int taps;

    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && _GameManager.Instance.currentScreen == "prep")
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider && tappable == true)
                {
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => Debug.Log("tapped!");
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => anim.SetTrigger("tap");
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => _Tracker.Instance.taps++;
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                tappable = false;
            }
        }
    }
}
