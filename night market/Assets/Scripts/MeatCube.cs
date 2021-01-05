using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCube : MonoBehaviour
{
    Transform tr;
    public Transform mashedState;
    SpriteRenderer spRend;

    public List<Sprite> cubes;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        spRend.sprite = cubes[Random.Range(1, cubes.Count)];
    }

    void Update()
    {
        if(this.GetComponent<Mashable>().mashed == true)
        {
            Instantiate(mashedState, new Vector3(tr.position.x, tr.position.y, tr.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
