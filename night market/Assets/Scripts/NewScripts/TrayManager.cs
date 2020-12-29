using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    Collider2D col;
    Transform tr;

    public Camera cam;

    float startPosY;

    public int itemsOnTray;

    void Start()
    {
        cam = _GameManager.Instance.cam;
        
        col = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();

        startPosY  = tr.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        //show the tray it is on the equipment/pantry screen
        if (_GameManager.Instance.currentScreen == "pantry" || _GameManager.Instance.currentScreen == "equipment")
        {
            tr.position = new Vector3(cam.transform.position.x, (startPosY + 3f), tr.position.z);
        }
        //if there are items on the tray, show on the prep screen
        else if (_GameManager.Instance.currentScreen == "prep" && itemsOnTray > 0)
        {
            //tr.position = new Vector3(cam.transform.position.x, (startPosY + 3f), tr.position.z);
            tr.transform.position = new Vector3(cam.transform.position.x, startPosY, tr.position.z);
            cam.transform.position = new Vector3(cam.transform.position.x, -3f, cam.transform.position.z);
        }
        //otherwise hide tray on prep screen
        else
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 0f, cam.transform.position.z);
            tr.position = new Vector3(cam.transform.position.x, startPosY, tr.position.z);
        }
    }

    //item is dragged on tray
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = tr.transform;
        itemsOnTray++;
    }

    //item is dragged off tray
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
        itemsOnTray--;
    }
}
