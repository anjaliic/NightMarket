using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    string meat = "meat";
    string rice = "rice_col";
    
    public GameObject col1;
    public GameObject col2;
    public GameObject col3;

    public int mixesNeeded;
    public int mixMid;
    public int mixCount;

    public bool mix1;
    public bool mix2;
    public bool mix3;

    public bool mixing;

    public Transform meatballPrefab;
    public Sprite riceMid;
    public Sprite riceBall;


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

            if (touch.phase == TouchPhase.Moved && mixing == true)
            {
                //find meat cubes 
                Collider2D touchedCollider1 = Physics2D.OverlapPoint(touchPosition);
                if(col1 == null)
                {
                    col1 = touchedCollider1.gameObject;
                    mix1 = true;
                }
                Collider2D touchedCollider2 = Physics2D.OverlapPoint(touchPosition);
                if (col2 == null && touchedCollider2.gameObject != col1)
                {
                    col2 = touchedCollider2.gameObject;
                    mix2 = true;
                }
                Collider2D touchedCollider3 = Physics2D.OverlapPoint(touchPosition);
                if (col3 == null && touchedCollider3.gameObject != col1 && touchedCollider3.gameObject != col2)
                {
                    col3 = touchedCollider3.gameObject;
                    mix3 = true;
                }

                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(touchedCollider.gameObject == col1)
                {
                    mix1 = true;
                }
                if (touchedCollider.gameObject == col2)
                {
                    mix2 = true;
                }
                if (touchedCollider.gameObject == col3)
                {
                    mix3 = true;
                }


                /*Collider2D touchedCollider2 = Physics2D.OverlapPoint(touchPosition);
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
                }*/
            }
        }
        if (mixing == true)
        {
            if (mix1 && mix2 && mix3)
            {
                mixCount++;
                mix1 = false; mix2 = false; mix3 = false;
            }
            if (mixCount == mixesNeeded)
            {
                if (col1.gameObject.name == meat)
                {
                    Instantiate(meatballPrefab, FindCenterPoint(), Quaternion.identity);
                    Destroy(col1);
                    Destroy(col2);
                    Destroy(col3);
                    mixing = false;
                }
                else if(col1.gameObject.name == rice)
                {
                    col1.gameObject.GetComponentInParent<SpriteRenderer>().sprite = riceBall;
                    Destroy(col1);
                    Destroy(col2);
                    Destroy(col3);
                    mixing = false;
                }
            }
            if(mixCount == mixMid) 
            {
                if(col1.gameObject.name == rice)
                {
                    col1.gameObject.GetComponentInParent<SpriteRenderer>().sprite = riceMid;
                }
            }
        }
    }

    Vector3 FindCenterPoint()
    {
        float xpos = (col1.transform.position.x + col2.transform.position.x + col3.transform.position.x) / 3;
        float ypos = (col1.transform.position.y + col2.transform.position.y + col3.transform.position.y) / 3;
        float zpos = (col1.transform.position.z + col2.transform.position.z + col3.transform.position.z) / 3;

        return new Vector3(xpos, ypos, zpos);
    }

}
