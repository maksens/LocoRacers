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
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_currentWayPointIndex = 0;
        m_currentWayPoint = GameController.m_instance.m_wayPoints[m_currentWayPointIndex].transform.position;
	}
	
	private void FixedUpdate ()
    {
        if(m_raceHasStarted && m_isActive)
        {
            CarMovement();
        }
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
    }

    protected override void UseItem()
    {

        if(m_hasTacos && Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers))
        {
            SpawnObject(m_weaponSlot.transform, GameController.m_instance.m_weapons[0]);
        }
        if(m_hasBoost && !Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers))
        {
            UseBoost(transform, m_rigidbody);
        }
    }

    protected override void CarMovement()
    {
        m_rigidbody.AddForce(transform.forward * m_carSpeed * Time.deltaTime);
        RotateCarAI(GameController.m_instance.m_wayPoints[m_currentWayPointIndex].transform.position, transform, m_carTurnSpeed);
    }
}
