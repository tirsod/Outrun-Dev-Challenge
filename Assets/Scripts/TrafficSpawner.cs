using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrafficSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _carPrefabs;
    private List<GameObject> _cars = new List<GameObject>();


    void OnEnable()
    {
        Game.started += StartSpawning;
        Game.stopped += StopSpawning;
    }

    void OnDisable()
    {
        Game.started -= StartSpawning;
        Game.stopped -= StopSpawning;
    }

    void SpawnCar()
    {
        var newCar = _carPrefabs[
            Mathf.FloorToInt(Random.Range(0, _carPrefabs.Length - 1))
        ];

        Vector3 carPosition = new Vector3(
            0,
            0f,
            100
        );

        var car = GameObject.Instantiate(newCar, carPosition, Quaternion.identity);
        _cars.Add(car);
    }

    void CleanCars()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (var car in cars)
        {
            Destroy(car);
        }
    }
    
    void StartSpawning()
    {
        CleanCars();
        InvokeRepeating(nameof(SpawnCar), 2f, 2f);
    }

    void StopSpawning()
    {
        CancelInvoke(nameof(SpawnCar));
    }
}
