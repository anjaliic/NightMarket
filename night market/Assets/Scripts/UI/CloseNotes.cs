using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNotes : MonoBehaviour
{
    public GameObject ChefsNotes;

    public void Close()
    {
        Debug.Log("close notes");
        ChefsNotes.SetActive(false);
    }
}
