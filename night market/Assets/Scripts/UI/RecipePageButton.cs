using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePageButton : MonoBehaviour
{
    public GameObject Page;

    public void changePage(string pagename)
    {
        Page.GetComponent<RecipePage>().currentPage = pagename;
    }
}
