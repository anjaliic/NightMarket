using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    public GameObject meat1;
    public GameObject meat2;
    public GameObject meat3;

    public int mixesNeeded;
    public int mixCount;

    public int count;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                Collider2D touchedCollider1 = Physics2D.OverlapPoint(touchPosition);
                if (touchedCollider1.tag =="mixable")
                {
                    meat1 = touchedCollider1.gameObject;
                    count++;
                }
                Collider2D touchedCollider2 = Physics2D.OverlapPoint(touchPosition);
                if (touchedCollider2.tag == "mixable")
                {
                    meat1 = touchedCollider2.gameObject;
                    count++;
                }
                Collider2D touchedCollider3 = Physics2D.OverlapPoint(touchPosition);
                if (touchedCollider3.tag == "mixable")
                {
                    meat1 = touchedCollider3.gameObject;
                    count++;
                }
            }
        }

        if(count == 3)
        {
            mixCount++;
            count = 0;
        }

        if(mixesNeeded == mixCount)
        {

        }
    }
}
