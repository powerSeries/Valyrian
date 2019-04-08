using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReload : MonoBehaviour
{
    public AudioSource ReloadSound;
    public GameObject Reticle;
    public int ClipSize = 10;
    public int ClipCount;
    public int TotalCount;
    public int ReloadAvailable;
    public AutoGunFire GunObject;

    void Start()
    {
        ClipCount = 0;
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
        //Autogunfire object for Auto guns
        GunObject = GetComponent<AutoGunFire>();
        //CharacterObject = GetComponent<CharacterVitality>();
    }

    private void GetAmmoCounts()
    {
        //ClipCount = CharacterObject.LoadedAmmoCount;
        //TotalCount = CharacterObject.TotalAmmoCount;
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
        //only one reload left
        //CharacterObject.LoadedAmmoCount += TotalCount;
        //CharacterObject.TotalAmmoCount -= TotalCount;
    }

    private void AnotherReload()
    {
        //enough reserve for more than a single reload
        //CharacterObject.LoadedAmmoCount += ReloadAvailable;
        //CharacterObject.TotalAmmoCount -= ReloadAvailable;
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
        //is there a reload available?
        if (ReloadAvailable >= 1)
        {
            return true;
        }
        return false;
    }

    IEnumerator EnableScripts()
    {
        //reenable scripts to update
        yield return new WaitForSeconds(1.1f);
        GunObject.enabled = true;
        Reticle.SetActive(true);
    }

    private void DisableScripts()
    {
        //disable scripts so they stop updating
        GunObject.enabled = false;
        Reticle.SetActive(false);
    }

    void ActionReload()
    {
        DisableScripts();
        ReloadSound.Play();
        GetComponent<Animation>().Play("Reload");
    }
}
