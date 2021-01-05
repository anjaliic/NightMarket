using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour
{
    public Transform onigiri;
    public GameObject riceball;

    void Update()
    {
       if(this.GetComponent<Swipeable>().swiped == true)
        {
            Instantiate(onigiri, new Vector3(riceball.transform.position.x,
                        riceball.transform.position.y, riceball.transform.position.z), Quaternion.identity);

            Destroy(this.gameObject);
            Destroy(riceball);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("riceball"))
        {
            this.GetComponent<Swipeable>().enabled = true;
            riceball = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("riceball"))
        {
            this.GetComponent<Swipeable>().enabled = false;
        }
    }


}
