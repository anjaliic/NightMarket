using UnityEngine;

public class Meatball : MonoBehaviour
{
    public Sprite cookedMeatball;
    SpriteRenderer sprRend;

    public int secondsToCook;
    public int secondsCooked;

    public bool onRice;

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

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Ended)
            {
               if(onRice == true)
                {
                    this.GetComponent<DragOnTray>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "rice")
        {
            onRice = true;
        }
    }
}
