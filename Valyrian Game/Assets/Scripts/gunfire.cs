using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfire : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource gunsound;
            gunsound = GetComponent<AudioSource>();
            gunsound.Play();
            GetComponent<Animation>().Play("PistolShot");
        }
    }
}
