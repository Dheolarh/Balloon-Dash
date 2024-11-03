using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private PlayerControllerX _gameOver;

    private float xRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _gameOver = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameOver.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < -xRange && (gameObject.CompareTag("Bomb") || gameObject.CompareTag("Money")))
        {
            Destroy(gameObject);
        }
    }
}
