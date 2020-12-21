using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrafficCar : MonoBehaviour
{

    private int _lanes = 5;
    private int _lane = 0;
    private float _laneSize = 4f;

    private bool isDead = false;

    void Start()
    {
        _lane = Mathf.FloorToInt(Random.Range(-2f, 2f));
        
        Invoke(nameof(ChangeLane), Random.Range(5f, 20f));

        Vector3 position = transform.position;
        float lanePosition = (_laneSize * _lane) - Mathf.FloorToInt( _laneSize / _lanes );
        position.x = lanePosition;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isDead = true;
        }
    }

    void ChangeLane()
    {
        _lane += Random.Range(-1, 2);
        _lane = Mathf.Clamp(_lane, -2, 2);
    }
    
    void Move()
    {
        Vector3 position = transform.position;

        float lanePosition = (_laneSize * _lane) - Mathf.FloorToInt( _laneSize / _lanes );
        position.x = Mathf.Lerp(position.x, lanePosition, 0.2f);

        position.z += (10f - GameVariables.speed) * Time.deltaTime;
        if (position.z <= -10f) Destroy(gameObject); 
        
        transform.position = position;
    }
    
    void Update()
    {
        if (!isDead) Move();
    }
}
