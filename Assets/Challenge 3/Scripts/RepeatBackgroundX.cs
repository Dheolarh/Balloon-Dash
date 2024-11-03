using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPosition;
    private float offset;
    private void Start()
    {
        startPosition = new Vector3(45, 9.5f, 4);
        transform.position = startPosition;
        offset = GetComponent<BoxCollider>().size.x / 2;
    }
    
    private void Update()
    {
        if (transform.position.x < startPosition.x - offset)
        {
            transform.position = startPosition;
        }
    }

 
}


