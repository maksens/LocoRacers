using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController m_instance;
    public BaseCar m_playerCar;
    public Dictionary<GameObject, BaseCar> m_baseCars = new Dictionary<GameObject, BaseCar>();
    public List<GameObject> m_weapons;
    public List<GameObject> m_wayPoints;
    public GameObject[] m_players;
    public PauseScreen m_pauseMenu;
    public BattleFieldHudScript m_bfHud;
    public BattleFieldVictoryScript m_bfVictoryScreen;
    public LasManStandingScript m_lastManScript;
    public bool m_gameIsPaused;
    public bool m_raceHasStarted = false;
    public bool m_raceHasEnded = false;
    public int m_maxLapCount = 6;
    public int m_nbOfAi = 1;
    public int m_raceNumber;
    public PlayerStats m_playerData;
    public RaceStats m_raceData;
    public Race2Stats m_race2Data;
    public Race3Stats m_race3Data;
    public Race4Stats m_race4Data;
    public VictoryScreen m_victoryScreen;
    public Camera m_mainCam;

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
        Screen.SetResolution(1920, 1080, true);
    }

    public void StartTheRace()
    {
        m_raceHasStarted = true;
    }
}
