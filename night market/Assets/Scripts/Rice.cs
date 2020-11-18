using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour
{
    public bool onigiri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onigiri == true)
        {
            this.gameObject.tag = "done";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "meatball")
        {
            this.GetComponent<DragOnTray>().enabled = false;
        }
    }
}
