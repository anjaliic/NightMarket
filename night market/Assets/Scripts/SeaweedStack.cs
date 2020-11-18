using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedStack : MonoBehaviour
{

    public Transform seaweedPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (touchedCollider.name == "seaweedstack")
                {
                    Instantiate(seaweedPrefab, new Vector3(touchPosition.x, touchPosition.y, 10f), Quaternion.identity);
                    this.enabled = false;
                }
            }
        }
    }
}
