using System.Collections;
using UnityEngine;

public class SemiGunFire : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = .5f;
    public float weaponRange = 5f;
    public float hitForce = 100f;
    public int Recoil = 0;
    public int ClipReserve = 10;

    public SemiReload ReloadScript;
    //public CharacterVitality PlayerObject;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private WaitForSeconds sightsDuration = new WaitForSeconds(.15f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    public bool aiming = false;
    private float nextFire;

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {
        CheckInput();
    }

    private void InitializeComponents()
    {
        ReloadScript = GetComponent<SemiReload>();
        //PlayerObject = GetComponent<CharacterVitality>();
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    private void CheckInput()
    {
        if (PressedAimButton())
        {
            AimDownSights();
        }
        else if(!PressingAimButton() && aiming)
        {
            CancelSights();
        }
        else
        {
            CheckIfFiring();
        }
    }

    public void CheckIfFiring()
    {
        if (PressedFireButton() && TimeToShoot() && PressingAimButton())
        {
            FireGunWhileAiming();
        }
        else if (PressedFireButton() && TimeToShoot())
        {
            FireGunWithoutAiming();
        }
    }

    private void FireGunWhileAiming()
    {
        if (ClipAmmoLeft())
        {
            SetNextFireTime();
            StartCoroutine(ShotEffectSights());
            RayCastDetection();
        }
    }

    private void FireGunWithoutAiming()
    {
        if (ClipAmmoLeft())
        {
            SetNextFireTime();
            StartCoroutine(ShotEffect());
            RayCastDetection();
        }
    }

    private bool ClipAmmoLeft()
    {
        //Is there ammo left in the clip
        if(ClipReserve > 0)
        {
            return true;
        }
        return false;
    }

    private void RayCastDetection()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        laserLine.SetPosition(0, gunEnd.position);

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
        }

    }

    public bool PressedFireButton()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        return false;
    }

    private bool PressedAimButton()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            return true;
        }
        return false;
    }

    private bool PressingAimButton()
    {
        if (Input.GetButton("Fire2"))
        {
            return true;
        }
        return false;
    }

    private bool TimeToShoot()
    {
        if (Time.time > nextFire)
        {
            return true;
        }
        return false;
    }

    private void AimDownSights()
    {
        aiming = true;
        GetComponent<Animation>().Play("AimDownSights");
    }

    private void CancelSights()
    {
        aiming = false;
        GetComponent<Animation>().Play("CancelSights");
    }

    private void SetNextFireTime()
    {
        nextFire = Time.time + fireRate;
    }

    private void ApplyRecoil()
    {
        //Player Object Variant Rotation.x += recoil;
    }

    private void EnableDebugRaycastLine()
    {
        laserLine.enabled = true;
    }

    private void DisableDebugRaycastLine()
    {
        laserLine.enabled = false;
    }

    private void FireGun()
    {
        gunAudio.Play();
        ApplyRecoil();
    }

    private IEnumerator ShotEffect()
    {
        //shoot the gun normal
        FireGun();
        GetComponent<Animation>().Play("Recoil");
        yield return shotDuration;
    }

    private IEnumerator ShotEffectSights()
    {
        //shoot the gun aiming down the sights
        FireGun();
        GetComponent<Animation>().Play("RecoilSights");
        yield return shotDuration;
    }
}