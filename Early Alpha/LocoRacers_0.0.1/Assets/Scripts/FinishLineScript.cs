using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            if (GameController.m_instance.m_baseCars[aCol.gameObject].m_wayPointCount >= 4)
            {
                GameController.m_instance.m_baseCars[aCol.gameObject].m_lapCount++;
                GameController.m_instance.m_baseCars[aCol.gameObject].m_wayPointCount = 0;
            }
        }
    }
}
