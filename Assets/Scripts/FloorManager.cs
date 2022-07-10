using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] floorPrefab = Array.Empty<GameObject>();

    public void SpawnFloor()
    {
       var floorType =  Random.Range(0, floorPrefab.Length);
       var floor = floorPrefab[floorType];
       floor.transform.position = new Vector3(Random.Range(-3.0f, 3.0f), -6, 0);
       Instantiate(floor, transform);
    }
}
