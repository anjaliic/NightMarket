using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Tracker : MonoBehaviour
{ 

    //maybe put a tracker on each ingredient & if they are in the bounds of the prep screen they are added to the list
    public static _Tracker Instance { get; private set; }
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

    public Dictionary<string, int> ingredientCount = new Dictionary<string, int>();
    public List<string> ingredients;

    string tempKey;
    int tempValue;

    //other variables to track
    public int taps;

    void Start()
    {
        ingredients.Add("meatcube");
        ingredients.Add("mashedmeat");
        foreach (string item in ingredients)
        {
            ingredientCount.Add(item, 0);
        } 
    }

    void Update()
    {
        Lean.Touch.LeanTouch.OnFingerTap += (x) => taps++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (KeyValuePair<string, int> item in ingredientCount)
        {
            // Access the key with item.Key
            // Access the value with item.Value
            if(collision.gameObject.name == item.Key)
            {
                tempKey = item.Key;
                tempValue = item.Value + 1;
                AddIngredient();   
            }
        }
    }

    void AddIngredient()
    {
        ingredientCount[tempKey] = tempValue;
        Debug.Log(tempKey + ": " + ingredientCount[tempKey]);
        tempKey = null;
    }

     private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
