using System.Collections;
using UnityEngine;

public class SemiGunFire : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = .5f;
    public float weaponRange = 5f;
    public float hitForce = 100f;
    public int recoil = 0;
    public GameObject PlayerObject;
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
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    private void CheckInput()
    {
        if (PressedAimButton())
        {
            AimDownSights();
        } else if(!PressingAimButton() && aiming)
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
        SetNextFireTime();
        StartCoroutine(ShotEffectSights());
        RayCastDetection();
    }

    private void FireGunWithoutAiming()
    {
        SetNextFireTime();
        StartCoroutine(ShotEffect());
        RayCastDetection();
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

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();

        laserLine.enabled = true;
        ApplyRecoil();
        GetComponent<Animation>().Play("Recoil");
        yield return shotDuration;
        laserLine.enabled = false;
    }

    private IEnumerator ShotEffectSights()
    {
        gunAudio.Play();

        laserLine.enabled = true;
        ApplyRecoil();
        GetComponent<Animation>().Play("RecoilSights");
        yield return shotDuration;
        laserLine.enabled = false;
    }
}