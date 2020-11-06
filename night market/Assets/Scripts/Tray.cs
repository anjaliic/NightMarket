using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public GameObject cam;
    public string currentScreen;

    Collider2D col;
    Transform tr;

    SpriteRenderer sp;
    
    public int itemsOnTray = 0;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        Debug.Log(col);

        col.enabled = false;
        sp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentScreen = cam.gameObject.GetComponent<CameraManager>().currentScreen;
        tr.transform.position = new Vector3(cam.transform.position.x, tr.position.y, tr.position.z);

        if(currentScreen != "prep" || (currentScreen == "prep" && itemsOnTray != 0))
        {
            col.enabled = true;
            sp.enabled = true;
        }
        else
        {
            col.enabled = false;
            sp.enabled = false;
        }

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
        itemsOnTray--;
    }
}
