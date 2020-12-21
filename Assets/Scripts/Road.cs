using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField]
    private float _roadLength;
    
    void Update()
    {
        Vector3 position = transform.position;

        position.z -= GameVariables.speed * Time.deltaTime;

        if (position.z < -_roadLength) position.z += _roadLength;

        transform.position = position;
    }
}
