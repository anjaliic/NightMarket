using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour
{
    CircleCollider2D riceCol;
    public Transform ricePrefab;

    public Sprite empty;
    SpriteRenderer spRend;

    // Start is called before the first frame update
    void Start()
    {
        riceCol = GetComponent<CircleCollider2D>();
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentScreen == "prep")
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (touchedCollider.GetType() == typeof(CircleCollider2D))
                    {
                        Debug.Log("touched rice");
                        Debug.Log("instantiating rice");
                        spRend.sprite = empty;
                        Instantiate(ricePrefab, new Vector3(touchPosition.x, touchPosition.y, this.transform.position.z), Quaternion.identity);
                        this.enabled = false;
                    }
                }
            }
        }
    }
}
