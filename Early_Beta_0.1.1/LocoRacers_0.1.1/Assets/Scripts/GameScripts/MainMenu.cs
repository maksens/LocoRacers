using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas m_raceSelectionScreen;
    public Canvas m_battleFieldSelectionScreen;
    public InputField m_field;
    public PlayerStats m_playerData;
    public Button[] m_races;
    public int m_currentRaceChoice = 0;

    public void Start()
    {
        Screen.SetResolution(800, 450, true);
    }

    public void Update ()
    {
        m_playerData.PlayerName = m_field.text;
	}

    public void OpenRaceSelection()
    {
        m_raceSelectionScreen.gameObject.SetActive(true);
        m_battleFieldSelectionScreen.gameObject.SetActive(false);
    }

    public void OpenFreeForAll()
    {
        m_battleFieldSelectionScreen.gameObject.SetActive(true);
        m_raceSelectionScreen.gameObject.SetActive(false);
    }

    public void SwipeLeft()
    {
        m_races[m_currentRaceChoice--].gameObject.SetActive(false);

        if (m_currentRaceChoice < 0)
        {
            m_currentRaceChoice = m_races.Length - 1;
        }

        m_races[m_currentRaceChoice].gameObject.SetActive(true);
    }

    public void SwipeRight()
    {
        m_races[m_currentRaceChoice++].gameObject.SetActive(false);

        if(m_currentRaceChoice > m_races.Length - 1)
        {
            m_currentRaceChoice = 0;
        }

        m_races[m_currentRaceChoice].gameObject.SetActive(true);
    }

    public void LoadRace(int aLvl)
    {
        SceneManager.LoadScene(aLvl);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
