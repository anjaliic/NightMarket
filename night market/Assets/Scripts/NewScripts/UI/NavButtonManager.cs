using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavButtonManager : MonoBehaviour
{
    public GameObject cam;

    public GameObject toPantry;
    public GameObject toEquipment;
    public GameObject fromPantry;
    public GameObject fromEquipment;


    // Update is called once per frame
    void Update()
    {

        if (_GameManager.Instance.currentScreen == "prep")
        {
            toPantry.SetActive(true);
            toEquipment.SetActive(true);
            fromPantry.SetActive(false);
            fromEquipment.SetActive(false);
        }
        else if (_GameManager.Instance.currentScreen == "pantry")
        {
            toPantry.SetActive(false);
            toEquipment.SetActive(false);
            fromPantry.SetActive(true);
            fromEquipment.SetActive(false);
        }
        else if (_GameManager.Instance.currentScreen == "equipment")
        {
            toPantry.SetActive(false);
            toEquipment.SetActive(false);
            fromPantry.SetActive(false);
            fromEquipment.SetActive(true);
        }

    }


}
