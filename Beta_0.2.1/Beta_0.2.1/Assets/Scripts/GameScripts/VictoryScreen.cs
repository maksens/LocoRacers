using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public Text[] m_playersName;
    public Text[] m_playersTime;
    public Text[] m_currentBestTime;
    public Canvas m_victoryCanvas;
    public bool m_newRecord = false;

    IEnumerator TypeWriter()
    {
        for(int i = 0; i < m_playersName.Length; i++)
        {
            string[] playerStats = ReturnAppropriateString(GameController.m_instance.m_raceNumber, i+1);

            for (int j = 0; j < playerStats[0].Length; j++)
            {
                m_playersName[i].text += playerStats[0][j];
                yield return new WaitForSeconds(0.35f);
            }
            for (int k = 0; k < playerStats[1].Length; k++)
            {
                m_playersTime[i].text += playerStats[1][k];
                yield return new WaitForSeconds(0.35f);
            }
        }

        string record = GameController.m_instance.m_race2Data.RecordTime.ToString();
        m_currentBestTime[0].gameObject.SetActive(true);

        for (int i = 0; i < record.Length; i++)
        {
            m_currentBestTime[0].text += record[i];

            yield return new WaitForSeconds(0.35f);

        }
        if (m_newRecord)
        {
            m_currentBestTime[1].gameObject.SetActive(true);
        }
    }

    public void StartTyping()
    {
        StartCoroutine("TypeWriter");
    }

    public string[] ReturnAppropriateString(int race, int player)
    {
        string[] playerNameAndTimer = new string[2];
        switch (race)
        {
            case 1:
                switch(player)
                {
                    case 1:
                        playerNameAndTimer[0] = GameController.m_instance.m_raceData.FirstPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_raceData.FirstPositionTimer.ToString();
                        break;
                    case 2:
                        playerNameAndTimer[0] = GameController.m_instance.m_raceData.SecondPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_raceData.SecondPositionTimer.ToString();
                        break;
                    case 3:
                        playerNameAndTimer[0] = GameController.m_instance.m_raceData.ThirdPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_raceData.ThirdPositionTimer.ToString();
                        break;
                    case 4:
                        playerNameAndTimer[0] = GameController.m_instance.m_raceData.FourthPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_raceData.FourthPositionTimer.ToString();
                        break;
                }
                break;
            case 2:
                switch (player)
                {
                    case 1:
                        playerNameAndTimer[0] = GameController.m_instance.m_race2Data.FirstPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race2Data.FirstPositionTimer.ToString();
                        break;
                    case 2:
                        playerNameAndTimer[0] = GameController.m_instance.m_race2Data.SecondPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race2Data.SecondPositionTimer.ToString();
                        break;
                    case 3:
                        playerNameAndTimer[0] = GameController.m_instance.m_race2Data.ThirdPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race2Data.ThirdPositionTimer.ToString();
                        break;
                    case 4:
                        playerNameAndTimer[0] = GameController.m_instance.m_race2Data.FourthPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race2Data.FourthPositionTimer.ToString();
                        break;
                }
                break;
            case 3:
                switch (player)
                {
                    case 1:
                        playerNameAndTimer[0] = GameController.m_instance.m_race3Data.FirstPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race3Data.FirstPositionTimer.ToString();
                        break;
                    case 2:
                        playerNameAndTimer[0] = GameController.m_instance.m_race3Data.SecondPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race3Data.SecondPositionTimer.ToString();
                        break;
                    case 3:
                        playerNameAndTimer[0] = GameController.m_instance.m_race3Data.ThirdPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race3Data.ThirdPositionTimer.ToString();
                        break;
                    case 4:
                        playerNameAndTimer[0] = GameController.m_instance.m_race3Data.FourthPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race3Data.FourthPositionTimer.ToString();
                        break;
                }
                break;
            case 4:
                switch (player)
                {
                    case 1:
                        playerNameAndTimer[0] = GameController.m_instance.m_race4Data.FirstPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race4Data.FirstPositionTimer.ToString();
                        break;
                    case 2:
                        playerNameAndTimer[0] = GameController.m_instance.m_race4Data.SecondPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race4Data.SecondPositionTimer.ToString();
                        break;
                    case 3:
                        playerNameAndTimer[0] = GameController.m_instance.m_race4Data.ThirdPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race4Data.ThirdPositionTimer.ToString();
                        break;
                    case 4:
                        playerNameAndTimer[0] = GameController.m_instance.m_race4Data.FourthPosition;
                        playerNameAndTimer[1] = GameController.m_instance.m_race4Data.FourthPositionTimer.ToString();
                        break;
                }
                break;
        }
        return playerNameAndTimer;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(GameController.m_instance.m_raceNumber);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
