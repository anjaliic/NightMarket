using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapping : MonoBehaviour
{
    Collider2D col;
    int count = 0;
    public int chops;
    public bool choppable = true;

    
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && choppable == true)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    
                    Debug.Log("chop");
                    anim.SetTrigger("tap");
                    count++;
                }
            }
        }

        if(count == chops)
        {
            choppable = false;
            Debug.Log("done chopping");
            
        }

    }
}
