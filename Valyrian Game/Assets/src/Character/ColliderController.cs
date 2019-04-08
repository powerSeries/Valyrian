using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderController : MonoBehaviour
{
    //List of possible weapons user can use 
    public GameObject M4A1;
    public GameObject AK47;
    public GameObject SAR;
    public GameObject M9;

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

    //Checks to see if the player is colliding with a weapon
    private bool IsWeapon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GetComponent<CharacterVitality>();

        ammoCount = PlayerObject.TotalAmmoCount;

        shieldCount = PlayerObject.ShieldCount;

        //changes the value of the text to current ammo amount
        SetCountText("Ammo");

        UpdateShieldBar();
    }

    /// <summary>
    /// Sets the Weapons attached the player model to be inactive this
    /// is to ensure that no player starts with a weapon.
    /// </summary>
    void SetWeaponsInactive()
    {
        M4A1.SetActive(false);
        AK47.SetActive(false);
        SAR.SetActive(false);
        M9.SetActive(false);
    }

    /// <summary>
    /// When a player collides with an object and that object has IsTrigger active.
    /// This function will run and will check the tag of the object and if
    /// it is 'Ammo' or 'Shield' it will increase the count of what that object
    /// represents by a fixed value. Then it will change what value is displayed on the
    /// screen.
    /// 
    /// It also checks if it is possible for a player to be able to pick up a weapon
    /// This check was in place because of a occuring issue that when you pick up a shield or ammo
    /// it would make your weapon disappear
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

        if(WeaponCheck(other))
        {
            PossibleWeapon(other);
        }
        
    }

    /// <summary>
    /// Used to check to see if the player is colliding with a weapon
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool WeaponCheck(Collider other)
    {
        if (other.gameObject.CompareTag("M4A1") || other.gameObject.CompareTag("AK47") || other.gameObject.CompareTag("M9") || other.gameObject.CompareTag("SAR"))
        {
            return true;
        }
        else
            return false;
    }


    /// <summary>
    /// This weapon determines which weapon to set as the active sweapon for the player
    /// </summary>
    /// <param name="weapon"></param>
    void PossibleWeapon(Collider weapon)
    {
        SetWeaponsInactive();

        if (weapon.gameObject.CompareTag("AK47"))
        {
            AK47.SetActive(true);
        }
        else if(weapon.gameObject.CompareTag("M4A1"))
        {
            M4A1.SetActive(true);
        }
        else if(weapon.gameObject.CompareTag("M9"))
        {
            M9.SetActive(true);
        }
        else if(weapon.gameObject.CompareTag("SAR"))
        {
            SAR.SetActive(true);
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

    /// <summary>
    /// This functions is used to update the players shield bar when they
    /// begin to collect shield packs. It will begin to fill up a baby blue
    /// bar right on top of where the health bar is at. Changes the X scale component
    /// of the image
    /// </summary>
    void UpdateShieldBar()
    {
        float ratio = (float)shieldCount / MAX_SHIELD;

        currentShieldBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        shieldText.text = (ratio * 100).ToString("0");
    }
}
