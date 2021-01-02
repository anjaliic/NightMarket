using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Sprite defaultSp;
    public Sprite firingSp;

    //public GameObject fireDetection;

    SpriteRenderer spRend;
    Animator anim;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("fire", true);
        spRend.sprite = firingSp;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spRend.sprite = defaultSp;
        anim.SetBool("fire", false);
    }
}
