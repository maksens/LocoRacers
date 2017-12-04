using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundCamera : MonoBehaviour
{
    public GameObject m_player;
    private Vector3 m_offset;
    private float m_timer = 0;

    private void Start()
    {
        m_offset = m_player.transform.position - transform.position;
    }

    private void Update ()
    {
        if(!GameController.m_instance.m_baseCars[m_player].isDead)
            transform.position = m_player.transform.position - m_offset;
        else if((m_timer += Time.deltaTime) >= 3)
        {
            transform.position = GameController.m_instance.m_baseCars[m_player].m_tireSpawn.transform.position;
        }

    }
}
