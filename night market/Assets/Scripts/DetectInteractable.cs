using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "tappable")
        {
            this.GetComponentInParent<Tapping>().enabled = true;
            this.GetComponentInParent<Tapping>().ingredient = collision.gameObject;
        }
        else if(collision.tag == "fireable")
        {
            this.GetComponentInParent<BreatheFire>().firing = true;
            this.GetComponentInParent<BreatheFire>().ingredient = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tappable")
        {
            this.GetComponentInParent<Tapping>().enabled = false;
            this.GetComponentInParent<Tapping>().ingredient = collision.gameObject;
        }
        else if (collision.tag == "fireable")
        {
            this.GetComponentInParent<BreatheFire>().firing = false;
            this.GetComponentInParent<Tapping>().ingredient = null;
        }
    }
}
