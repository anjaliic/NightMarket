using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCustomer : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spRend;
    Transform tr;

    int customer;

    public Color targetColor = new Color(1, 1, 1, 1);
    Vector3 targetSize = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();

        customer = Random.Range(0, sprites.Length);
        spRend.sprite = sprites[customer];
        StartCoroutine(LerpFunction(targetColor, targetSize, 10));
    }

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
    }
}
