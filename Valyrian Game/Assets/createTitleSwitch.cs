using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTitleSwitch : MonoBehaviour
{
    GameObject titleCamera;
    GameObject createGameCamera;
    // Start is called before the first frame update
    public void onClick()
    {
        titleCamera.SetActive(false);
        createGameCamera.SetActive(true);
    }
}
