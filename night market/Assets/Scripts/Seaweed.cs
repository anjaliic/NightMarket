using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour
{
    public GameObject col1;
    public GameObject col2;

    public GameObject rice;
    public Sprite onigiri;

    public bool swiped;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(swiped == true)
        {
            rice.GetComponent<SpriteRenderer>().sprite = onigiri;
            rice.GetComponent<Rice>().onigiri = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "rice")
        {
            col1.SetActive(true);
            col2.SetActive(true);
            this.GetComponent<DragOnTray>().enabled = false;
            rice = collision.gameObject;
        }
    }


}
