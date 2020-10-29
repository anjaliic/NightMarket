using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public GameObject GameMng;
    public string currentScreen;

    Collider2D col;
    public Camera cam;
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
        currentScreen = GameMng.gameObject.GetComponent<GameManager>().currentScreen;
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

        /*if(currentScreen == "prep" && itemsOnTray > 0)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, -2.75f, cam.transform.position.z);
            this.transform.position = new Vector3(tr.transform.position.x, -6.42f, tr.transform.position.z);
        }
        else
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 0f, cam.transform.position.z);
            this.transform.position = new Vector3(tr.transform.position.x, -3.66f, tr.transform.position.z);
        }*/
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
