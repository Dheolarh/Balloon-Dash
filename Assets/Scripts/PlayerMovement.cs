using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRB;
    private Animator _playerAN;
    public Transform _camera;

    private Vector3 offset = new Vector3(-0.1f, 1.6f, -2);
    private float moveForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerAN = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float walkForward = Input.GetAxis("Vertical");
        float walkSideways = Input.GetAxis("Horizontal");
        bool run = Input.GetKey(KeyCode.LeftShift);
        
        _playerRB.AddForce(Vector3.forward * walkForward * moveForce, ForceMode.Impulse);
        _playerRB.AddForce(Vector3.right * walkSideways * moveForce, ForceMode.Impulse);
        
        bool isWalking = walkForward != 0 || walkSideways != 0;
        bool isRunning = (walkForward != 0 && run) || (walkSideways != 0 && run);
        _playerAN.SetBool("Walking", isWalking);
        _playerAN.SetBool("Running", isRunning);
        
    }

    private void LateUpdate()
    {
        _camera.position = gameObject.transform.position + offset;
        Debug.Log("Logging");
    }
}
