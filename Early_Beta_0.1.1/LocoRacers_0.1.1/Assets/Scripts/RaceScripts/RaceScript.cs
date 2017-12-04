using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceScript : MonoBehaviour
{
    private List<Vector3> m_positions = new List<Vector3>();
    private Vector3 m_currentRespawnPosition = new Vector3(-10000, -10000, -10000);
    private float m_respawnDistance = 10000;
    private const float RESPAWNTIMER = 2f;

    private void Start()
    {
        foreach (GameObject waypoint in GameController.m_instance.m_wayPoints)
        {
            m_positions.Add(waypoint.transform.position);
        }
    }

    private void OnTriggerExit(Collider aCol)
    {
        aCol.gameObject.transform.position = SortWaypointsPosition(aCol.gameObject);
    }

    private Vector3 SortWaypointsPosition(GameObject aGameObject)
    {
        m_respawnDistance = 10000;
        foreach (Vector3 position in m_positions)
        {
            if(Vector3.Distance(position, aGameObject.transform.position) < m_respawnDistance)
            {
                m_respawnDistance = Vector3.Distance(position, aGameObject.transform.position);
                m_currentRespawnPosition = position;
            }
        }
        return m_currentRespawnPosition;
    }

    private void CaculatePosition()
    {

    }
}
