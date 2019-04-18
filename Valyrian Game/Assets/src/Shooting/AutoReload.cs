using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReload : MonoBehaviour
{
    public AudioSource ReloadSound;
    public GameObject Reticle;
    public int ClipSize = 10; //default 10 initiate
    public int ClipCount;
    public int TotalCount = 0;
    public int ReloadAvailable;
    public AutoGunFire GunObject;

    public bool Reloading = false;

    void Start()
    {
        ClipCount = ClipSize;
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

    bool AmmoToShoot()
    {
        if (ClipCount > 0)
        {
            return true;
        }
        return false;
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

            if (ReloadAvailable > TotalCount)
            {
                ReloadAvailable = TotalCount;
            }

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
        //only enough reserve for a single reload
        ClipCount += TotalCount;
        TotalCount = 0;
        GunObject.ClipReserve = ClipCount;
    }

    private void AnotherReload()
    {
        //enough reserve for more than a single reload
        ClipCount += ReloadAvailable;
        TotalCount -= ReloadAvailable;
        GunObject.ClipReserve = ClipCount;
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
        Reloading = true;
    }
}
