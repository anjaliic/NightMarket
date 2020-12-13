using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayManager : MonoBehaviour
{
    Collider2D col;
    Transform tr;

    public GameObject cam;

    float startYPos;

    //smoothdamp
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        tr = GetComponent<Transform>();

        startYPos  = tr.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        //slide up if on pantry or equipment screen (smoothdamp)
        if (_GameManager.Instance.currentScreen == "pantry" || _GameManager.Instance.currentScreen == "equipment")
        {
            if (tr.position.y == startYPos)
            {
                tr.position = new Vector3(cam.transform.position.x, startYPos, tr.position.z);
                Vector3 targetPosition = new Vector3(cam.transform.position.x, startYPos + 3f, -10);
                tr.position = Vector3.SmoothDamp(tr.position, targetPosition, ref velocity, smoothTime);
            }
        }
        else
        {
            //tr.position = new Vector3(cam.transform.position.x, startYPos, tr.position.z);
        }
    }
}
