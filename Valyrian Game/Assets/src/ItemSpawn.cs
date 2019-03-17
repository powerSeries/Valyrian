using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //Serialize the gameobject in order to create more of the object
    [SerializeField]
    private GameObject itemPrefab;

    private void Start()
    {
        //Create a new gameobject of what itemPrefab is, give it the rotation and position of current object
        Instantiate(itemPrefab, transform.position, transform.rotation);
    }
}
