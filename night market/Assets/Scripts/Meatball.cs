using UnityEngine;

public class Meatball : MonoBehaviour
{
    public Sprite cookedMeatball;
    SpriteRenderer sprRend;

    public int secondsToCook;
    public int secondsCooked;
    
    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(secondsToCook == secondsCooked)
        {
            sprRend.sprite = cookedMeatball;
        }
    }
}
