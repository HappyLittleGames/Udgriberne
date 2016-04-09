﻿using UnityEngine;
using System.Collections;

public class MoonController : MonoBehaviour {

    private float m_SpeedMod = 1;
    public float SpeedMod
    {
        get { return m_SpeedMod * Speed; }
        set { m_SpeedMod = value; }
    }
    [SerializeField]
    [Range(0f, 50f)]
    private float m_Speed = 8;
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }

    int InputMove = 0;
    bool InputJump;

    void GetInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        { InputMove = -1; }

        else if (Input.GetKey(KeyCode.LeftArrow))
        { InputMove = 1; }

        else
        { InputMove = 0; }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        { InputJump = true; }
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate ()
    {
        
        transform.Rotate(0, 0, InputMove * SpeedMod);
        if(InputJump)
        {
            transform.Rotate(0, 0, 180);
            InputJump = false;
        }
	}
    
}
