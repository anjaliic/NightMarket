using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefNotesUI : MonoBehaviour
{
   public void closeNotes()
    {
        GameManager.Instance.notes = false;
    }
}
