using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int player;

    private String axis;

    // Use this for initialization
    void Start()
    {
        if (player == 1)
        {
            axis = "P1_Vertical";
        }
        else
        {
            axis = "P2_Vertical";
        }
    }

    // Update is called once per frame
    void Update()
    {
        var y = Input.GetAxis(axis) * Time.deltaTime * speed;
        var bound = Camera.main.GetComponent<Camera>().orthographicSize * 0.85f;    

        transform.Translate(0,y,0);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-bound,bound), transform.position.z);
    }
}