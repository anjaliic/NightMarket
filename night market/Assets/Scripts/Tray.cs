using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public GameObject cam;

    Collider2D col;
    Transform tr;

    SpriteRenderer sp;
    
    public int itemsOnTray = 0;

    public bool onPrepScreen;
    public bool onTray;

    public float startYPos;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        Debug.Log(col);

        col.enabled = false;
        sp.enabled = false;

        startYPos = tr.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        tr.transform.position = new Vector3(cam.transform.position.x, startYPos, tr.position.z);

        if (GameManager.Instance.currentScreen == "prep" && itemsOnTray > 0)
        {
            onTray = true;
        }
        if(onTray == true && GameManager.Instance.currentScreen == "prep" && itemsOnTray == 0)
        {
            col.enabled = false;
            sp.enabled = false;
            onTray = false;
        }
        if(onTray == true)
        {
            tr.transform.position = new Vector3(cam.transform.position.x, startYPos - 3, tr.position.z);
            cam.transform.position = new Vector3(cam.transform.position.x, -3f, cam.transform.position.z);
        }
        else if(onTray == false)
        {
            tr.transform.position = new Vector3(cam.transform.position.x, startYPos, tr.position.z);
            cam.transform.position = new Vector3(cam.transform.position.x, 0f, cam.transform.position.z);
        }

    }

    public void hideTray()
    {
        if(itemsOnTray == 0)
        {
            col.enabled = false;
            sp.enabled = false;
        }
        else
        {
            col.enabled = true;
            sp.enabled = true;
        }
    }

    public void showTray()
    {
        col.enabled = true;
        sp.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<DragOnTray>().onTray = true;
        itemsOnTray++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("off tray");
        collision.gameObject.GetComponent<DragOnTray>().onTray = false;
        collision.gameObject.transform.parent = null;
        itemsOnTray--;
    }
}
