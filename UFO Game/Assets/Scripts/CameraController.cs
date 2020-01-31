﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
