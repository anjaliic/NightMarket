using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Vector3 startingPos;

    Transform tr;
    Collider2D col;

    public bool draggable;
    public Vector2 firstTouch;
    public Vector2 touchPosition;

    void Start()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        tr = GetComponent<Transform>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        //drag & drop
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                firstTouch = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                Debug.Log(touchedCollider.gameObject);
                if(col == touchedCollider)
                {
                    StartCoroutine(WaitToDrag());

                    IEnumerator WaitToDrag()
                    {

                        yield return new WaitForSeconds(.05f);

                        if (touchPosition == firstTouch)
                        {
                            draggable = true;
                        }
                    }
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (draggable == true)
                {
                    transform.position = new Vector3(touchPosition.x, touchPosition.y, tr.position.z);
                }

            }

        }
        else
        {
            draggable = false;
        }
    }

}
