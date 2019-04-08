using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReload : MonoBehaviour
{
    public AudioSource ReloadSound;
    public GameObject Reticle;
    //public GameObject MechanicsObject;
    public int ClipSize = 10;
    public int ClipCount;
    public int TotalCount;
    public int ReloadAvailable;
    public AutoGunFire GunObject;
    public CharacterVitality CharacterObject;

    void Start()
    {
        InitiateObjects();
    }

    void Update()
    {
        GetAmmoCounts();
        CheckIfReloadAvailable();
        CheckForReload();
    }

    private void InitiateObjects()
    {
        GunObject = GetComponent<AutoGunFire>();
        CharacterObject = GetComponent<CharacterVitality>();
    }

    private void GetAmmoCounts()
    {
        ClipCount = CharacterObject.LoadedAmmoCount;
        TotalCount = CharacterObject.TotalAmmoCount;
    }

    private void CheckIfReloadAvailable()
    {
        if (TotalCount == 0)
        {
            ReloadAvailable = 0;
        }
        else
        {
            ReloadAvailable = ClipSize - ClipCount;
        }
    }

    private void CheckForReload()
    {
        if (PressedReloadButton())
        {
            if (AnyReloadAvailable())
            {
                CheckAvailableAmmo();
            }
            StartCoroutine(EnableScripts());
        }
    }

    private void CheckAvailableAmmo()
    {
        if (TotalCount <= ReloadAvailable)
        {
            LastReload();
        }
        else
        {
            AnotherReload();
        }
        ActionReload();
    }

    private void LastReload()
    {
        CharacterObject.LoadedAmmoCount += TotalCount;
        CharacterObject.TotalAmmoCount -= TotalCount;
    }

    private void AnotherReload()
    {
        CharacterObject.LoadedAmmoCount += ReloadAvailable;
        CharacterObject.TotalAmmoCount -= ReloadAvailable;
    }

    private bool PressedReloadButton()
    {
        if (Input.GetButtonDown("Reload"))
        {
            return true;
        }
        return false;
    }

    private bool AnyReloadAvailable()
    {
        if (ReloadAvailable >= 1)
        {
            return true;
        }
        return false;
    }

    IEnumerator EnableScripts()
    {
        yield return new WaitForSeconds(1.1f);
        GunObject.enabled = true;
        Reticle.SetActive(true);
        //MechanicsObject.SetActive(true);
    }

    void ActionReload()
    {
        GunObject.enabled = false;
        Reticle.SetActive(false);
        //MechanicsObject.SetActive(false);
        ReloadSound.Play();
        GetComponent<Animation>().Play("Reload");
    }
}
