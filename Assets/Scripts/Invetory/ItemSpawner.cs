using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : ItemComponent
{
    public Transform prefab;

    public int i = 0;

    public override void Use()
    {
        if(i < 3)
        {
            Debug.Log("working");
            Instantiate(prefab,new Vector3(i * 2f, 0, 0), Quaternion.identity);
            i++;
        }
       
    }

   
}
