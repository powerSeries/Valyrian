using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVitality : MonoBehaviour
{
    public int LoadedAmmoCount = 0;
    public int TotalAmmoCount = 0;
    public int ShieldCount = 0;
    public int HealthCount = 100;
    public bool alive = true;

    public GameObject PlayerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
    }

    private void CheckLife()
    {
        if (HealthCount <= 0 && alive)
        {
            KillCharacter();
        }
    }

    private void KillCharacter()
    {
        alive = false;
        PlayerObject.SetActive(false);
    }
}