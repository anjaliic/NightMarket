using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NavButtons : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        //finds & sets the Main Camera to cam
        cam = cam.GetComponent<Camera>();
    }

    //On Click () function on Button component
    //moves camera to the input xpos float
    public void moveCamera(float xpos)
    {
        //changes the x position of the camera to xpos
        cam.transform.position = new Vector3(xpos, cam.transform.position.y, cam.transform.position.z);
    }

}
