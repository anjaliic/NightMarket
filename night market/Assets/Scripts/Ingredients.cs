using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps track of all ingredients on the prep screen 
public class Ingredients : MonoBehaviour
{
    public static Ingredients Instance { get; private set; }

    public GameObject meat1;
    public GameObject meat2;
    public GameObject meat3;

    public GameObject mix;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(meat1.tag == "mixable" && meat2.tag == "mixable" && meat3.tag == "mixable")
        {
            mix.GetComponent<Mix>().mixing = true;
        }
    }
}
