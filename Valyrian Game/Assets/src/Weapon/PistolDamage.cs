using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolDamage : MonoBehaviour
{
    int DamageAmount = 5;
    float TargetDistance;
    float AllowedRange = 15;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }



}
