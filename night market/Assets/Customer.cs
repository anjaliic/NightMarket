using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool getFood = false;
    public GameObject food;

    public Sprite heart;
    SpriteRenderer spRend;

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Ended)
            {
                if(getFood == true)
                {
                    Destroy(food);
                    spRend.sprite = heart;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "done")
        {
            getFood = true;
            food = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "done")
        {
            getFood = false;
            food = collision.gameObject;
        }
    }
}
