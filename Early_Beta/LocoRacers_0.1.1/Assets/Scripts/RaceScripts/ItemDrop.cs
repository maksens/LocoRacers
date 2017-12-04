﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private BaseCar m_b;
    private int m_rand = 0;
    private int m_respawnTimer = 2;
    private Vector3 m_position;
    private Vector3 m_VoidPosition = new Vector3(123, -123, -123);

    private void Start()
    {
        m_position = transform.position;
    }

    IEnumerator ItemPickUp()
    {
        transform.position = m_VoidPosition;
        yield return new WaitForSeconds(m_respawnTimer);
        transform.position = m_position;
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            m_rand = Random.Range(0, 2);

            if(m_rand == 0)
            {
                m_b = GameController.m_instance.m_baseCars[aCol.gameObject];
                m_b.m_hasTacos = true;
                m_b.m_hasBoost = false;
                StartCoroutine("ItemPickUp");
            }
            else if (m_rand == 1)
            {
                m_b = GameController.m_instance.m_baseCars[aCol.gameObject];
                m_b.m_hasTacos = false;
                m_b.m_hasBoost = true;
                StartCoroutine("ItemPickUp");
            }                                               // More Objects will be avalaible in next patch!!
            //else if (m_rand == 2)
            //{
            //    Lightning
            //    StartCoroutine("ItemPickUp");
            //}
            //else if (m_rand == 3)
            //{
            //    Oil Spread
            //    StartCoroutine("ItemPickUp");
            //}
        }
    }
}
