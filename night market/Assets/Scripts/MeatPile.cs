using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPile : MonoBehaviour
{
    Transform tr;
    public Transform meatcubePrefab;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (this.GetComponent<Tappable>().tapped == true)
        {
            Instantiate(meatcubePrefab, new Vector3(tr.transform.position.x, tr.transform.position.y, tr.transform.position.z), Quaternion.identity);
            this.GetComponent<Tappable>().tapped = false;
        }
    }
}

