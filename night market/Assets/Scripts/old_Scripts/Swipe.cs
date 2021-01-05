using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject col1;
    public GameObject col2;

    public bool swipe1;
    public bool swipe2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
               
                Collider2D touchedCollider1 = Physics2D.OverlapPoint(touchPosition);
                if (col1 == null && touchedCollider1.tag == "swipable")
                {
                    col1 = touchedCollider1.gameObject;
                    swipe1 = true;
                }
                Collider2D touchedCollider2 = Physics2D.OverlapPoint(touchPosition);
                if (col2 == null && touchedCollider2.tag == "swipable")
                {
                    col2 = touchedCollider2.gameObject;
                    swipe2 = true;
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                col1 = null;
                col2 = null;
                swipe1 = false;
                swipe2 = false;
            }
        }

        if (swipe1 && swipe2)
        {
            col1.gameObject.GetComponentInParent<Seaweed>().swiped = true;
        }
    }
}
