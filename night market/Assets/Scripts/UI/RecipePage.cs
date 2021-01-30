using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePage : MonoBehaviour
{
    public static RecipePage Instance { get; private set; }

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

    public int currentPage = 0;
    Image image;

    public List<Sprite> pageSprites;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = pageSprites[currentPage];
    }

    void Update()
    {
        if(GetComponent<Swipeable>().swiped == true)
        {
            if(currentPage < pageSprites.Count)
            {
                currentPage++;
                image.sprite = pageSprites[currentPage];
            }
            
            GetComponent<Swipeable>().swiped = false;
        }
    }
}
