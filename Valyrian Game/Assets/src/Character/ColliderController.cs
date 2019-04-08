using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderController : MonoBehaviour
{
    //MAX amount of Shield a player can have
    private const int MAX_SHIELD = 100;
    private const int SHIELD_AMOUNT = 25;
    private const int AMMO_AMOUNT = 15;

    //CharacterVitality is used for getting the objects health
    public CharacterVitality PlayerObject;

    //text object to display ammo amount
    public Text ammoText;

    //text object to display shield amount
    public Text shieldText;
    public Image currentShieldBar;

    //counters for the ammo/shield amount
    private int ammoCount;
    private int shieldCount;

    //Checks to see if the player shield is full
    private bool IsShieldFull;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = PlayerObject.TotalAmmoCount;

        shieldCount = PlayerObject.ShieldCount;

        //changes the value of the text to current ammo amount
        SetCountText("Ammo");

        UpdateShieldBar();
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
        SetIsFull();


        if (other.gameObject.CompareTag("Ammo"))
        {
            other.gameObject.SetActive(false);
            ammoCount += AMMO_AMOUNT;
            SetCountText(other.tag);
        }
        

        if(!IsShieldFull)
        {
            if (other.gameObject.CompareTag("Shield"))
            {
                other.gameObject.SetActive(false);

                ShieldCalculator(shieldCount);
                UpdateShieldBar();
                SetCountText(other.tag);
            }
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

    /// <summary>
    /// This functions helps with the possiblity of players going
    /// over the limit that we have set on the shield. By calculating
    /// how much the player needs to reach the MAX shield amount we can 
    /// determine when to give them the full amount of the shield or just
    /// give them enough to get them to the MAX.
    /// </summary>
    /// <param name="shieldCount"></param>
    void ShieldCalculator(int currentShield)
    {
        int differenceToFull = Mathf.Abs(currentShield - MAX_SHIELD);

        if (differenceToFull >= SHIELD_AMOUNT)
        {
            shieldCount += SHIELD_AMOUNT;
        }
        else if (differenceToFull < SHIELD_AMOUNT)
        {
            shieldCount += differenceToFull;
        }
    }

    /// <summary>
    /// This functions checks if the player is already at the
    /// max amount of shield that they can have. 
    /// </summary>
    void SetIsFull()
    {
        if (shieldCount >= MAX_SHIELD)
        {
            IsShieldFull = true;
        }
        else
        {
            IsShieldFull = false;
        }

    }

    void UpdateShieldBar()
    {
        float ratio = (float)shieldCount / MAX_SHIELD;

        currentShieldBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        shieldText.text = (ratio * 100).ToString("0");
    }
}
