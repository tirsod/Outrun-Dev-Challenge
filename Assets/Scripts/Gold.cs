using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    void Update()
    {
        Vector3 pos = transform.position;

        pos.z += -GameVariables.speed * Time.deltaTime;
        
        if (pos.z <= -10f) Destroy(gameObject);
        
        transform.position = pos;
    }
}
