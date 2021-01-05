using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    public bool lineofFire;
    public Collider2D fireDetection;

    public int seconds;
    
    public int cookTime;
    //public int burnTime;

    public bool cooked;

    public bool firing;
    public bool counting;

    void Start()
    { 
        fireDetection = GameObject.Find("fireDetection").GetComponent<Collider2D>();
    }

    void Update()
    {
        if (firing == true)
        {
            if (counting == true)
            {
                StartCoroutine(addSecond());
            }
        }

        if(seconds == cookTime)
        {
            cooked = true;
        }
    }

    IEnumerator addSecond()
    {
        counting = false;
        yield return new WaitForSeconds(1);
        seconds++;
        counting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == fireDetection)
        {
            firing = true;
            counting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == fireDetection)
        {
            firing = false;
        }
    }
}
