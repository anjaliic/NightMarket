using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesTab : MonoBehaviour
{
    public int pageToJump;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnTabClick);
    }

    void OnTabClick()
    {
        RecipePage.Instance.currentPage = pageToJump;
        Debug.Log("clicked");
    }
}
