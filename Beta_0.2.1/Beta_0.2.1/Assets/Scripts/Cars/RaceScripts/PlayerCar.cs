﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : BaseCar
{
    private void Start()
    {
        CarName = GameController.m_instance.m_playerData.PlayerName;
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        IsAnAi = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameController.m_instance.m_pauseMenu.PauseGame();
        }

        if (GameController.m_instance.m_raceHasStarted && m_isActive && !m_raceHasEnded && !GameController.m_instance.m_gameIsPaused)
        {
            if (m_hasBeenStopped)
                m_hasBeenStopped = false;

            UseItem();
            m_raceTime += Time.deltaTime;
        }
        else if (!m_isActive && GameController.m_instance.m_raceHasStarted)
        {
            transform.Rotate(Vector3.up * 10f);
        }

        if (GameController.m_instance.m_gameIsPaused)
        {
            if (!m_hasBeenStopped)
            {
                m_idlePosition = transform.position;
                m_hasBeenStopped = true;
            }
            else
            {
                transform.position = m_idlePosition;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameController.m_instance.m_raceHasStarted && !m_raceHasEnded && m_isActive && !GameController.m_instance.m_gameIsPaused)
        {
            CarMovement();
        }
    }

    protected override void CarMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (m_wheel.motorTorque >= m_carSpeed)
                m_wheel.motorTorque = m_carSpeed;
            else
            { m_wheel.motorTorque += 500 * Time.deltaTime; }
        }
        else
        { m_wheel.motorTorque = 0; }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            RotateCar(Vector3.left + Vector3.forward, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            RotateCar(Vector3.left + Vector3.back, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            RotateCar(Vector3.forward + Vector3.right, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            RotateCar(Vector3.back + Vector3.right, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotateCar(Vector3.left, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateCar(Vector3.right, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            RotateCar(Vector3.forward, transform, m_carTurnSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            RotateCar(Vector3.back, transform, m_carTurnSpeed);
        }
    }

    protected override void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.B) && !GameController.m_instance.m_gameIsPaused)
        {
            if (m_hasTacos)
            {
                GameObject go = SpawnObject(m_weaponSlot.transform, GameController.m_instance.m_weapons[0]);
                TacoScript t = go.GetComponent<TacoScript>();
                t.m_owner = gameObject;
            }
            else if (m_hasBoost)
            {
                UseBoost(transform, m_rigidbody);
            }
        }
    }
}