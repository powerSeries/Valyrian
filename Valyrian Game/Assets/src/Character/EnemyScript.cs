using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int EnemyHealth = 100;
    public int EnemyShield = 0;

    void DeductPoints(int Damage)
    {
        EnemyHealth -= Damage;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
