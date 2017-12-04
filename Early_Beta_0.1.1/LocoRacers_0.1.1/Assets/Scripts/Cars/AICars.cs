using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICars : BaseCar
{
    public int m_currentWayPointIndex;
    public LayerMask m_layers;
    public Vector3 m_currentWayPoint;

    private void Start ()
    {
        m_carName = "AI # " + GameController.m_instance.m_nbOfAi++;
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_currentWayPointIndex = 0;
        m_currentWayPoint = GameController.m_instance.m_wayPoints[m_currentWayPointIndex].transform.position;
        m_isAnAi = true;
	}
	
	private void FixedUpdate ()
    {
        if(GameController.m_instance.m_raceHasStarted && m_isActive && !m_raceHasEnded && !GameController.m_instance.m_gameIsPaused)
        {
            CarMovement();
        }
	}

    private void Update()
    {
        if (GameController.m_instance.m_raceHasStarted && m_isActive && !m_raceHasEnded && !GameController.m_instance.m_gameIsPaused)
        {
            if (m_hasBeenStopped)
                m_hasBeenStopped = false;

            UseItem();
            m_raceTime += Time.deltaTime;
        }
        else if (!m_isActive && !GameController.m_instance.m_gameIsPaused)
        {
            transform.Rotate(Vector3.up * 10f);
        }

        if (MyVector.SmallerThanEpsilon(transform.position, GameController.m_instance.m_wayPoints[m_currentWayPointIndex].transform.position))
        {
            if (m_currentWayPointIndex < GameController.m_instance.m_wayPoints.Count - 1)
            {
                m_currentWayPointIndex++;
            }
            else
            {
                m_currentWayPointIndex = 0;
            }
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

    protected override void UseItem()
    {
        if(m_hasTacos && Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers) && !GameController.m_instance.m_gameIsPaused)
        {
            SpawnObject(m_weaponSlot.transform, GameController.m_instance.m_weapons[0]);
        }
        if(m_hasBoost && !Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers) && !GameController.m_instance.m_gameIsPaused)
        {
            UseBoost(transform, m_rigidbody);
        }
    }

    protected override void CarMovement()
    {
        if (m_wheel.motorTorque >= m_carSpeed)
            m_wheel.motorTorque = m_carSpeed;
        else
        { m_wheel.motorTorque += 50 * Time.deltaTime; }

        RotateCarAI(GameController.m_instance.m_wayPoints[m_currentWayPointIndex].transform.position, transform, m_carTurnSpeed);
    }
}
