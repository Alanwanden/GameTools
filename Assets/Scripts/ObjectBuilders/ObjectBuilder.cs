using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuilder : MonoBehaviour
{
    public GameObject obj;
    public Vector3 spawnPosistion;
    // Start is called before the first frame update
    public void SpawnObj()
    {
        Instantiate(obj,spawnPosistion,Quaternion.identity);
    }
}
