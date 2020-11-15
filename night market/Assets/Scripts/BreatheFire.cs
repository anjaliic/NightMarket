using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheFire : MonoBehaviour
{
    public Sprite fireSpr;
    public Sprite nofireSpr;
    SpriteRenderer spRend;

    public GameObject ingredient;

    public bool firing;
    public bool counting;

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(firing == true)
        {
            spRend.sprite = fireSpr;
            if(counting == true)
            {
                StartCoroutine(addSecond());
            }
        }
        else
        {
            spRend.sprite = nofireSpr;
        }
    }

    IEnumerator addSecond()
    {
        counting = false;
        yield return new WaitForSeconds(1);
        ingredient.GetComponent<Meatball>().secondsCooked++;
        counting = true;
    }
}
