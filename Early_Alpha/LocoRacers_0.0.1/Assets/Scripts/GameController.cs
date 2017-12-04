using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController m_instance;
    public Dictionary<GameObject, BaseCar> m_baseCars = new Dictionary<GameObject, BaseCar>();
    public List<GameObject> m_weapons;
    public List<GameObject> m_wayPoints;
    public GameObject[] m_players;
    public bool m_gameIsPaused;

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
    }


    private void Start ()
    {
        for (int i = 0; i < m_instance.m_players.Length; i++)
        {
            m_baseCars.Add(m_players[i], m_players[i].GetComponent<BaseCar>());
        }
    }

	private void Update ()
    {

	}
}
