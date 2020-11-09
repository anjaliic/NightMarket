using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    
    SpriteRenderer sprRend;
    public Sprite newState;

    public GameObject equipment;

    public bool choppable;

    public int tapsNeeded;
    public int tapCount;

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        /*if (equipment.GetComponent<Tapping>().choppable == false)
        {
            sprRend.sprite = newState;
        }*/

        if(tapsNeeded == tapCount)
        {
            sprRend.sprite = newState;
            gameObject.tag = "mixable";
            this.GetComponent<DragOnTray>().enabled = false;
        }
    }


}
