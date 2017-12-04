using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : BaseCar
{
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (m_raceHasStarted && m_isActive)
        {
            UseItem();
        }
        else if (!m_isActive)
        {
            transform.Rotate(Vector3.up * 10f);
        }

        Debug.Log("Lap :" + m_lapCount);
    }

    private void FixedUpdate()
    {
        if (m_raceHasStarted && m_isActive)
        {
            CarMovement();
        }
    }

    protected override void CarMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody.AddForce(transform.forward * m_carSpeed * Time.deltaTime);
        }

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
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (m_hasTacos)
            {
                SpawnObject(m_weaponSlot.transform, GameController.m_instance.m_weapons[0]);
            }
            else if (m_hasBoost)
            {
                UseBoost(transform, m_rigidbody);
            }
        }
    }


}