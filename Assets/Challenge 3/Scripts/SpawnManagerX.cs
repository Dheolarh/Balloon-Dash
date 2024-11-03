using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] colletctablesPrefab;

    private PlayerControllerX _gameOver;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 2f, 2f);
        _gameOver = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        int spawnWidth = Random.Range(0, colletctablesPrefab.Length);
        Vector3 spawnRange = new Vector3(22.3f, Random.Range(2.5f, 16f), 0);
        if (!_gameOver.gameOver)
        {
            Instantiate(colletctablesPrefab[spawnWidth], spawnRange, colletctablesPrefab[spawnWidth].transform.rotation);
        }
    }
}
