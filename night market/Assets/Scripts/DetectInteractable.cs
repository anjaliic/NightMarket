using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    //set what tag the object will search for to interact with
    public string interactionTag;

    //the ingredient the equipment is interacting with
    public GameObject ingredient;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == interactionTag)
        {
            this.GetComponentInParent<Tapping>().enabled = true;
            ingredient = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == interactionTag)
        {
            this.GetComponentInParent<Tapping>().enabled = false;
        }
    }
}
