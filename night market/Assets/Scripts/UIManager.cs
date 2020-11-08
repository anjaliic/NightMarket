using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject cam;

    public GameObject toFood;
    public GameObject toPantry;
    public GameObject fromFood;
    public GameObject fromPantry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.currentScreen == "prep")
        {
            toFood.SetActive(true);
            toPantry.SetActive(true);
            fromFood.SetActive(false);
            fromPantry.SetActive(false);
        }
        else if(GameManager.Instance.currentScreen == "food")
        {
            toFood.SetActive(false);
            toPantry.SetActive(false);
            fromFood.SetActive(true);
            fromPantry.SetActive(false);
        }
        else if (GameManager.Instance.currentScreen == "pantry")
        {
            toFood.SetActive(false);
            toPantry.SetActive(false);
            fromFood.SetActive(false);
            fromPantry.SetActive(true);
        }


    }


}
