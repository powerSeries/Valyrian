using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderController : MonoBehaviour
{
    public CharacterVitality PlayerObject;
    //text object to display ammo amount
    public Text ammoText;

    //text object to display shield amount
    public Text shieldText;

    //counters for the ammo/shield amount
    private int ammoCount;
    private int shieldCount;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = PlayerObject.TotalAmmoCount;

        shieldCount = PlayerObject.ShieldCount;

        //changes the value of the text to current ammo amount
        SetCountText("Ammo");

        //changes the value of the text to current shield amount
        SetCountText("Shield");
    }

    /// <summary>
    /// When a player collides with an object and that object has IsTrigger active.
    /// This function will run and will check the tag of the object and if
    /// it is 'Ammo' or 'Shield' it will increase the count of what that object
    /// represents by a fixed value. Then it will change what value is displayed on the
    /// screen.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            other.gameObject.SetActive(false);
            ammoCount += 15;
            SetCountText(other.tag);
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            other.gameObject.SetActive(false);
            if (shieldCount < 100)
            {
                shieldCount += 25;
            }
            if (shieldCount > 100)
            {
                shieldCount = 100;
            }
            SetCountText(other.tag);
        }
    }


    /// <summary>
    /// This function changes the value of the amount of
    /// ammo or shield the player has. Depeding on the tag
    /// the function will update the value. 
    /// </summary>
    /// <param name="tag"></param>
    void SetCountText(string tag)
    {
        if (tag == "Ammo")
        {
            ammoText.text = ammoCount.ToString();
        }
        else if (tag == "Shield")
        {
            shieldText.text = shieldCount.ToString();
        }
    }
}
