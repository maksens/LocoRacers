using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            if(GameController.m_instance.m_baseCars.ContainsKey(aCol.gameObject))
            {
                if(!GameController.m_instance.m_baseCars[aCol.gameObject].m_hasCrossedWayPoint)
                {
                    GameController.m_instance.m_baseCars[aCol.gameObject].m_wayPointCount++;
                }
            }
        }
    }
}
