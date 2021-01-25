using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCustomer : MonoBehaviour
{
    public Sprite[] sprites;
    public string[] recipes;

    SpriteRenderer spRend;
    Transform tr;

    int customer;
    string order;

    public bool hover;

    public Color targetColor = new Color(1, 1, 1, 1);
    Vector3 targetSize = new Vector3(1, 1, 1);

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();

        NewCustomer();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

            if (touch.phase == TouchPhase.Ended && hover == true)
            {
                NewCustomer();              
            }
        }
    }

    void NewCustomer()
    {
        customer = Random.Range(0, sprites.Length);
        order = recipes[Random.Range(0, recipes.Length)];

        spRend.sprite = sprites[customer];
        StartCoroutine(LerpFunction(targetColor, targetSize, 2));

        IEnumerator LerpFunction(Color endValue, Vector3 endSize, float duration)
        {
            float time = 0;

            while (time < duration)
            {
                spRend.color = Color.Lerp(spRend.color, endValue, time / (duration * 5));
                tr.localScale = Vector3.Lerp(tr.localScale, endSize, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            spRend.color = endValue;
            tr.localScale = endSize;
            GameManager.Instance.activeCustomer = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "done")
        {
            hover = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "done")
        {
            hover = false;
        }
    }

}

