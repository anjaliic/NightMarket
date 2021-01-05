using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBowl : MonoBehaviour
{
    public Sprite emptyBowl;
    public Transform ricespread;

    SpriteRenderer spRend;

    public bool emptied;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(this.GetComponent<DoubleTap>().doubleTapped == true)
        {
            emptied = true; 
        }
        if(emptied == true)
        {
            Instantiate(ricespread, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            spRend.sprite = emptyBowl;
            this.enabled = false;
        }
    }
}
