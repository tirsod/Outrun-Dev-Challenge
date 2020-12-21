using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] private int _lane = 0;
    private float _laneSize = 4f;
    private int _lanes = 5;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void OnEnable()
    {
        Swipe.OnSwipeLeft += MoveLeft;
        Swipe.OnSwipeRight += MoveRight;
        Game.started += ResetCar;
    }

    private void OnDisable()
    {
        Swipe.OnSwipeLeft -= MoveLeft;
        Swipe.OnSwipeRight -= MoveRight;
        Game.started -= ResetCar;
    }

    private void ResetCar()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rb.isKinematic = true;
        _rb.useGravity = false;
        _lane = 0;
    }
    
    void MoveLeft()
    {
        if (!GameVariables.isDead) _lane -= 1;
    }

    void MoveRight()
    {
        if (!GameVariables.isDead) _lane += 1;
    }
    
    void Update()
    {
        int maxLane = Mathf.FloorToInt(_lanes / 2f);
        _lane = Mathf.Clamp(_lane, -maxLane, maxLane);
        
        MoveToLane();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Car") && !GameVariables.isDead)
        {
            Game.End();
            _rb.isKinematic = false;
            _rb.useGravity = true;
            _rb.AddForce(Vector3.up * 25f, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            Game.GetGold();
            Destroy(other.gameObject);
        }
    }

    void MoveToLane()
    {
        Vector3 position = transform.position;

        float lanePosition = (_laneSize * _lane) - Mathf.FloorToInt( _laneSize / _lanes );
        position.x = Mathf.Lerp(position.x, lanePosition, 0.2f);

        transform.position = position;
    }
    
}
