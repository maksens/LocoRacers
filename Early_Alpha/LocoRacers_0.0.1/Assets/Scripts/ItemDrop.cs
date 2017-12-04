using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private BaseCar b;
    private int rand = 0;

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            rand = Random.Range(0, 2);

            if(rand == 0)
            {
                b = aCol.gameObject.GetComponent<BaseCar>();
                b.m_hasTacos = true;
                b.m_hasBoost = false;
            }
            else if (rand == 1)
            {
                b = aCol.gameObject.GetComponent<BaseCar>();
                b.m_hasTacos = false;
                b.m_hasBoost = true;
            }
        }
    }
}
