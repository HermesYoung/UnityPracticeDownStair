using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private readonly float _speed = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));
        if (transform.position.y > 6.0)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<FloorManager>().SpawnFloor();
        }
    }
}
