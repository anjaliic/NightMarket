using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
    Collider2D col;

    public bool dTappable;
    public bool doubleTapped;

    public Sprite newSprite;
    public Transform result;

    SpriteRenderer spRend;

    void Start()
    {
        col = GetComponent<Collider2D>();
        spRend = GetComponent<SpriteRenderer>();
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

        if(doubleTapped == true)
        {
            Instantiate(result, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            spRend.sprite = newSprite;
            this.enabled = false;
        }
    }
}
