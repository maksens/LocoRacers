using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScrit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            GameController.m_instance.m_baseCars[other.gameObject].StartCoroutine("TacosHit");
        }
    }
}
