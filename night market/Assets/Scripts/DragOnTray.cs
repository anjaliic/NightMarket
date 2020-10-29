using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragOnTray : MonoBehaviour
{

    bool moveAllowed;
    Collider2D col;

    public bool onTray = false;
    Transform tr;
    public Camera cam;

    public float xpos;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //drag & drop
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed == true)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
                //gets the last xpos 
                //xpos = tr.transform.position.x;
            }
        }

        if (onTray == true)
        {
            //tr.transform.position = new Vector3((cam.transform.position.x - xpos), tr.position.y, tr.position.z);
            //maybe make object child of tray
            tr.transform.position = new Vector3(cam.transform.position.x, tr.position.y, tr.position.z);
        }
        else if (onTray == false && SceneManager.GetActiveScene().name == "Prep")
        {
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        }
        else if (onTray == false)
        {
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        }
    }
}
