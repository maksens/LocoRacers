using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldItemDrop : MonoBehaviour
{

    private BaseCar m_b;
    private int m_rand = 0;
    private int m_respawnTimer = 2;
    private Vector3 m_position;
    private Vector3 m_VoidPosition = new Vector3(123, -123, -123);
    private bool m_isActive;

    private void Start()
    {
        m_position = transform.position;
    }

    IEnumerator ItemPickUp()
    {
        m_isActive = false;
        transform.position = m_VoidPosition;
        yield return new WaitForSeconds(m_respawnTimer);
        transform.position = m_position;
        m_isActive = true;
    }

    public bool GetActiveState() { return m_isActive; }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            m_b = GameController.m_instance.m_baseCars[aCol.gameObject];
            m_b.HasBoost = false;
            m_b.HasTacos = true;
            StartCoroutine("ItemPickUp");
        }
    }
}
