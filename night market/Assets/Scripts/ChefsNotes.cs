using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefsNotes : MonoBehaviour
{
    public static ChefsNotes Instance { get; private set; }

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

    //public bool viewNotes;
    public GameObject Notes;

    void Update()
    {
        if(this.gameObject.GetComponent<DoubleTap>().doubleTapped == true)
        {
            //viewNotes = true;
            Notes.SetActive(true);
            this.gameObject.GetComponent<DoubleTap>().doubleTapped = false;
        }
    }
}
