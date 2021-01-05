using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mallet : MonoBehaviour
{
    public int taps;
    Animator anim;

    public float animLength;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Tappable>().tapped == true && _GameManager.Instance.currentScreen == "prep")
        {
            anim.SetTrigger("tap");
            this.GetComponent<Tappable>().tappable = false;
            StartCoroutine(Tap());
            this.GetComponent<Tappable>().tapped = false;
        }
    }

    IEnumerator Tap()
    {
        yield return new WaitForSeconds(animLength);
        taps++;
        this.GetComponent<Tappable>().tappable = true;
    }
}
