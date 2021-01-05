using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipeable : MonoBehaviour
{
    Collider2D col;
    public Transform result;

    public bool swipable;
    public bool swiped;

    public GameObject riceball;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
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
                    Lean.Touch.LeanTouch.OnFingerSwipe += (x) => swiped = true;
                }

            }
        }
        
        if(swiped == true)
        {
            Instantiate(result, new Vector3(riceball.transform.position.x,
                        riceball.transform.position.y, riceball.transform.position.z), Quaternion.identity);

            Destroy(this.gameObject);
            Destroy(riceball);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("riceball"))
        {
            swipable = true;
            riceball = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("riceball"))
        {
            swipable = false;
        }
    }

}
