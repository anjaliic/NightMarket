using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    
    SpriteRenderer sprRend;
    public Sprite newState;

    public GameObject equipment;

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (equipment.GetComponent<Tapping>().choppable == false)
        {
            sprRend.sprite = newState;
        }
    }


}
