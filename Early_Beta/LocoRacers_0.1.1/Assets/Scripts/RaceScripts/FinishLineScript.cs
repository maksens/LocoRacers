using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public bool m_winnerHasBeenDeclared = false;
    public bool m_secondHasBeenDeclared = false;
    public bool m_thirdHasBeenDeclared = false;
    public bool m_fourthHasBeenDeclared = false;
    public bool m_announcerHasPlayed = false;
    public AudioSource m_announcer;
    public AudioClip[] m_sound;

    private void Start()
    {
        m_announcer.clip = m_sound[0];
    }

    IEnumerator EndOfRace()
    {
        m_announcer.clip = m_sound[1];
        m_announcer.Play();
        GameController.m_instance.m_pauseMenu.m_audioS.Stop();
        yield return new WaitForSeconds(4);
        GameController.m_instance.m_victoryScreen.m_victoryCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        GameController.m_instance.m_victoryScreen.StartTyping();
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            BaseCar b = GameController.m_instance.m_baseCars[aCol.gameObject];

            if (b.m_wayPointCount >= GameController.m_instance.m_wayPoints.Count)
            {
                if(b.m_lapCount == GameController.m_instance.m_maxLapCount-2 && !m_announcerHasPlayed)
                {
                    m_announcer.Play();
                    m_announcerHasPlayed = true;
                }
                if (b.m_lapCount >= GameController.m_instance.m_maxLapCount - 1)
                {
                    if (!m_winnerHasBeenDeclared)
                    {
                        WriteRaceFinishOrder(GameController.m_instance.m_raceNumber, b);
                        m_winnerHasBeenDeclared = true;
                        b.m_raceHasEnded = true;
                    }
                    else if (!m_secondHasBeenDeclared)
                    {
                        WriteRaceFinishOrder(GameController.m_instance.m_raceNumber, b);
                        m_secondHasBeenDeclared = true;
                        b.m_raceHasEnded = true;
                    }
                    else if (!m_thirdHasBeenDeclared)
                    {
                        WriteRaceFinishOrder(GameController.m_instance.m_raceNumber, b);
                        m_thirdHasBeenDeclared = true;
                        b.m_raceHasEnded = true;
                    }
                    else if (!m_fourthHasBeenDeclared)
                    {
                        WriteRaceFinishOrder(GameController.m_instance.m_raceNumber, b);
                        m_fourthHasBeenDeclared = true;
                        b.m_raceHasEnded = true;
                        GameController.m_instance.m_raceHasEnded = true;
                        StartCoroutine("EndOfRace");
                    }
                }
                else
                {
                    b.m_lapCount++;
                    b.m_wayPointCount = 0;
                }
            }
        }
    }

    private void WriteRaceFinishOrder(int race, BaseCar b)
    {
        switch (race)
        {
            case 1:
                var raceStat = GameController.m_instance.m_raceData;
                if (!m_winnerHasBeenDeclared)
                {
                    raceStat.FirstPosition = b.m_carName;
                    raceStat.FirstPositionTimer = b.m_raceTime;

                    if (b.m_raceTime < raceStat.RecordTime)
                    {
                        raceStat.RecordTime = b.m_raceTime;
                        GameController.m_instance.m_victoryScreen.m_newRecord = true;
                    }
                }
                else if (!m_secondHasBeenDeclared)
                {

                    raceStat.SecondPosition = b.m_carName;
                    raceStat.SecondPositionTimer = b.m_raceTime;
                }
                else if (!m_thirdHasBeenDeclared)
                {
                    raceStat.ThirdPosition = b.m_carName;
                    raceStat.ThirdPositionTimer = b.m_raceTime;
                }
                else if (!m_fourthHasBeenDeclared)
                {
                    raceStat.FourthPosition = b.m_carName;
                    raceStat.FourthPositionTimer = b.m_raceTime;
                }
                break;
            case 2:
                var raceStat2 = GameController.m_instance.m_race2Data;
                if (!m_winnerHasBeenDeclared)
                {
                    raceStat2.FirstPosition = b.m_carName;
                    raceStat2.FirstPositionTimer = b.m_raceTime;

                    if (b.m_raceTime < raceStat2.RecordTime)
                    {
                        raceStat2.RecordTime = b.m_raceTime;
                        GameController.m_instance.m_victoryScreen.m_newRecord = true;
                    }
                }
                else if (!m_secondHasBeenDeclared)
                {

                    raceStat2.SecondPosition = b.m_carName;
                    raceStat2.SecondPositionTimer = b.m_raceTime;
                }
                else if (!m_thirdHasBeenDeclared)
                {
                    raceStat2.ThirdPosition = b.m_carName;
                    raceStat2.ThirdPositionTimer = b.m_raceTime;
                }
                else if (!m_fourthHasBeenDeclared)
                {
                    raceStat2.FourthPosition = b.m_carName;
                    raceStat2.FourthPositionTimer = b.m_raceTime;
                }
                break;
            case 3:
                var raceStat3 = GameController.m_instance.m_race3Data;
                if (!m_winnerHasBeenDeclared)
                {
                    raceStat3.FirstPosition = b.m_carName;
                    raceStat3.FirstPositionTimer = b.m_raceTime;

                    if (b.m_raceTime < raceStat3.RecordTime)
                    {
                        raceStat3.RecordTime = b.m_raceTime;
                        GameController.m_instance.m_victoryScreen.m_newRecord = true;
                    }
                }
                else if (!m_secondHasBeenDeclared)
                {

                    raceStat3.SecondPosition = b.m_carName;
                    raceStat3.SecondPositionTimer = b.m_raceTime;
                }
                else if (!m_thirdHasBeenDeclared)
                {
                    raceStat3.ThirdPosition = b.m_carName;
                    raceStat3.ThirdPositionTimer = b.m_raceTime;
                }
                else if (!m_fourthHasBeenDeclared)
                {
                    raceStat3.FourthPosition = b.m_carName;
                    raceStat3.FourthPositionTimer = b.m_raceTime;
                }
                break;
            case 4:
                var raceStat4 = GameController.m_instance.m_race4Data;
                if (!m_winnerHasBeenDeclared)
                {
                    raceStat4.FirstPosition = b.m_carName;
                    raceStat4.FirstPositionTimer = b.m_raceTime;

                    if (b.m_raceTime < raceStat4.RecordTime)
                    {
                        raceStat4.RecordTime = b.m_raceTime;
                        GameController.m_instance.m_victoryScreen.m_newRecord = true;
                    }
                }
                else if (!m_secondHasBeenDeclared)
                {

                    raceStat4.SecondPosition = b.m_carName;
                    raceStat4.SecondPositionTimer = b.m_raceTime;
                }
                else if (!m_thirdHasBeenDeclared)
                {
                    raceStat4.ThirdPosition = b.m_carName;
                    raceStat4.ThirdPositionTimer = b.m_raceTime;
                }
                else if (!m_fourthHasBeenDeclared)
                {
                    raceStat4.FourthPosition = b.m_carName;
                    raceStat4.FourthPositionTimer = b.m_raceTime;
                }
                break;
        }
    }
}
