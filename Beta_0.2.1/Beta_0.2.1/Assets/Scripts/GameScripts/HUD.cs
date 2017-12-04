using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text m_timeTextBox;
    public Text m_lapCountTextBox;
    public Text m_position;
    public Image[] m_lightsImg;
    public Image[] m_objectsImg;
    public int m_lapTotal;
    public int m_currentLap;

	public void Start ()
    {
        StartCoroutine("RaceStart");
	}

    public void Update()
    {
        ShowTimer();
        ShowItem();
        ShowCurrentLap();
        ShowCurrentPosition();
	}


    IEnumerator RaceStart()
    {
        m_lightsImg[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        m_lightsImg[1].gameObject.SetActive(true);
        m_lightsImg[0].gameObject.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        m_lightsImg[2].gameObject.SetActive(true);
        m_lightsImg[1].gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        m_lightsImg[2].gameObject.SetActive(false);
        GameController.m_instance.StartTheRace();
    }

    public void ShowTimer()
    {
        if (GameController.m_instance.m_playerCar.m_raceTime < 10)
            m_timeTextBox.text = "TIMER  0:0" + (int)GameController.m_instance.m_playerCar.m_raceTime;

        else if (GameController.m_instance.m_playerCar.m_raceTime < 60)
            m_timeTextBox.text = "TIMER  0:" + (int)GameController.m_instance.m_playerCar.m_raceTime;

        else if (GameController.m_instance.m_playerCar.m_raceTime >= 60)
        {
            int minTimer = (int)GameController.m_instance.m_playerCar.m_raceTime / 60;
            int secTimer = (int)GameController.m_instance.m_playerCar.m_raceTime % 60;

            if (secTimer < 10)
                m_timeTextBox.text = "TIMER  " + minTimer + ":0" + secTimer;

            else
                m_timeTextBox.text = "TIMER  " + minTimer + ":" + secTimer;
        }
    }

    public void ShowItem()
    {
        if(GameController.m_instance.m_playerCar.HasBoost)
        {
            m_objectsImg[0].gameObject.SetActive(true);
            m_objectsImg[1].gameObject.SetActive(false);
        }
        else if(GameController.m_instance.m_playerCar.HasTacos)
        {
            m_objectsImg[0].gameObject.SetActive(false);
            m_objectsImg[1].gameObject.SetActive(true);
        }
        else
        {
            m_objectsImg[0].gameObject.SetActive(false);
            m_objectsImg[1].gameObject.SetActive(false);
        }
    }
    
    public void ShowCurrentLap()
    {
        m_currentLap = GameController.m_instance.m_playerCar.m_lapCount + 1;
        m_lapTotal = GameController.m_instance.m_maxLapCount;

        if (m_currentLap >= m_lapTotal)
        {
            m_currentLap = m_lapTotal;
        }
        m_lapCountTextBox.text = "LAP : " + m_currentLap.ToString() + " / " + m_lapTotal.ToString();
    }

    private void ShowCurrentPosition()
    {
        LinkedList<BaseCar> cars = new LinkedList<BaseCar>();
        int count = 0;

        foreach(var go in GameController.m_instance.m_baseCars)
        {
            if (cars.Count > 0)
            {
                if(cars.Count == 3)
                {
                    if (cars.First.Value.m_lapCount <= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                        cars.First.Value.m_wayPointCount < GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if (cars.First.Next.Value.m_lapCount <= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                             cars.First.Next.Value.m_wayPointCount < GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddBefore(cars.First.Next, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if (cars.First.Next.Value.m_lapCount >= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                             cars.First.Next.Value.m_wayPointCount > GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddAfter(cars.First.Next, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if (cars.Last.Value.m_lapCount >= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                             cars.Last.Value.m_wayPointCount > GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddAfter(cars.Last, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                }
                else if (cars.Count == 2)
                {
                    if (cars.First.Value.m_lapCount <= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                        cars.First.Value.m_wayPointCount < GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if (cars.First.Next.Value.m_lapCount <= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                             cars.First.Next.Value.m_wayPointCount < GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddBefore(cars.First.Next, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if (cars.First.Next.Value.m_lapCount >= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                             cars.First.Next.Value.m_wayPointCount > GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddAfter(cars.First.Next, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                }
                else if(cars.Count == 1)
                {
                    if (cars.First.Value.m_lapCount <= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                        cars.First.Value.m_wayPointCount < GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else if(cars.First.Value.m_lapCount >= GameController.m_instance.m_baseCars[go.Key].m_lapCount &&
                            cars.First.Value.m_wayPointCount > GameController.m_instance.m_baseCars[go.Key].m_wayPointCount)
                    {
                        cars.AddAfter(cars.First, GameController.m_instance.m_baseCars[go.Key]);
                    }
                    else
                    {
                        cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
                    }
                }
            }
            else
            {
                cars.AddFirst(GameController.m_instance.m_baseCars[go.Key]);
            }
        }

        foreach(BaseCar b in cars)
        {
            count++;
            if (!b.IsAnAi)
            {
                m_position.text = count.ToString();
            }
        }
    }
}
