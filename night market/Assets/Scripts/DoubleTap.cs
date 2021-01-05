using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
    Collider2D col;

    public bool dTappable;
    public bool doubleTapped;

    void Start()
    {
        col = GetComponent<Collider2D>();
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
                if (col == touchedCollider)
                {
                   
                    Lean.Touch.LeanTouch.OnFingerTap += (x) => StartCoroutine(DoubleTapWithinTime());

                    if (dTappable == true)
                    {
                        Lean.Touch.LeanTouch.OnFingerTap += (x) => doubleTapped = true;
                        doubleTapped = false;
                    }

                    IEnumerator DoubleTapWithinTime()
                    {
                        dTappable = true;
                        yield return new WaitForSeconds(.2f);
                        dTappable = false;

                    }
                }
            }
        }
    }
}
