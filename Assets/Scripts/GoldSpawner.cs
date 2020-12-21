using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _coinPrefab;
    
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

    void CleanGold()
    {
        GameObject[] golds = GameObject.FindGameObjectsWithTag("Gold");

        foreach (var gold in golds)
        {
            Destroy(gold);
        }
    }
    
    void StartSpawning()
    {
        CleanGold();
        InvokeRepeating(nameof(SpawnCoin), 0.5f, 0.5f);
    }

    void StopSpawning()
    {
        CancelInvoke(nameof(SpawnCoin));
    }

    void SpawnCoin()
    {
        if (Random.Range(0, 100) > 75) return;
        Vector3 position = new Vector3(
            4f * Random.Range(-2, 2),
            0.5f,
            100
        );
        var newCoin = Instantiate(_coinPrefab, position, Quaternion.identity);
    }
}
