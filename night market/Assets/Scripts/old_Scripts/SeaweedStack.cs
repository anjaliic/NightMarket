using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedStack : MonoBehaviour
{
    Transform tr;
    public Transform seaweedPrefab;

    void Start()
    {
        tr = GetComponent<Transform>();  
    }

    void Update()
    {
        if(this.GetComponent<Tappable>().tapped == true)
        {
            Instantiate(seaweedPrefab, new Vector3(tr.transform.position.x, tr.transform.position.y, tr.transform.position.z), Quaternion.identity);
            this.GetComponent<Tappable>().tapped = false;
        }
    }
}
