using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapping : MonoBehaviour
{
    Collider2D col;
    int count = 0;
    public int chops;
    //public bool choppable = true;
    
    Animator anim;

    public GameObject ingredient;
    public string interactionTag;

    public bool canTap;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == interactionTag)
        {
            canTap = true;
            ingredient = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == interactionTag)
        {
            canTap = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && canTap == true)
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

                    ingredient.GetComponent<Meat>().tapCount++;
                }
            }
        }

        if(count == chops)
        {
            Debug.Log("done chopping");
            
        }

    }
}
