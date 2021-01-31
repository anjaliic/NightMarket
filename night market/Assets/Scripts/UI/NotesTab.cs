using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesTab : MonoBehaviour
{
    public void OnTabClick(int pageToJump)
    {
        RecipePage.Instance.currentPage = pageToJump;
        Debug.Log("clicked");
    }
}
