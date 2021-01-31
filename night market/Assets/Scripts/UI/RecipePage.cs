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
    public GameObject ChefsNotes;
    Image image;

    public List<Sprite> pageSprites;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = pageSprites[currentPage];
    }

    void Update()
    {
        image.sprite = pageSprites[currentPage];

        if (GetComponent<Swipeable>().swiped == true)
        {
            if(currentPage < pageSprites.Count)
            {
                currentPage++;
                
            }
            
            GetComponent<Swipeable>().swiped = false;
        }

        if(currentPage == -1)
        {
            currentPage = 0;
            ChefsNotes.SetActive(false);
        }
    }
}
