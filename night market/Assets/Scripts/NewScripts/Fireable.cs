using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    public bool lineofFire;
    public Collider2D fireDetection;
    public GameObject dragon;

    public int count;
    
    public int secondstoCook;
    public Sprite cookedSp;
   
    //public int secondtoBurn;
    //public Sprite burnt;

    public bool firing;
    public bool counting;

    SpriteRenderer spRend;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        fireDetection = GameObject.Find("fireDetection").GetComponent<Collider2D>();
        dragon = GameObject.Find("dragon");
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

        if(count == secondstoCook)
        {
            spRend.sprite = cookedSp;
        }
    }

    IEnumerator addSecond()
    {
        counting = false;
        yield return new WaitForSeconds(1);
        count++;
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
