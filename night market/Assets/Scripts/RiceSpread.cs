using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceSpread : MonoBehaviour
{
    public bool haveMeatball;
    public Transform riceball;

    Transform tr;

    Animator anim;

    public int count;

    public GameObject col1;
    public GameObject col2;
    public GameObject col3;

    void Start()
    {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(haveMeatball == true)
        {
            col1.SetActive(true);
            col2.SetActive(true);
            col3.SetActive(true);

            anim.enabled = true;
        }

        if(mMix.Instance.activeMix.Contains("rice"))
        {  
            count = mMix.Instance.mixCount;
            anim.SetInteger("triangles", count);
        }

        if(count == 5)
        {
            Instantiate(riceball, new Vector3(tr.position.x, tr.position.y, tr.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
