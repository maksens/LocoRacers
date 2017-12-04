using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasManStandingScript : MonoBehaviour
{
    public List<BaseCar> m_aliveRacers = new List<BaseCar>(4);
    public string m_winnerName;
    public bool m_winnerHasBeenDeclared = false;

    IEnumerator EndOfRace()
    {
        GameController.m_instance.m_bfHud.gameObject.SetActive(false);
        yield return new WaitForSeconds(4);
        GameController.m_instance.m_bfVictoryScreen.m_victoryCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        GameController.m_instance.m_bfVictoryScreen.StartTyping();
    }

    private void Start ()
    {
		foreach(var go in GameController.m_instance.m_baseCars)
        {
            m_aliveRacers.Add(go.Value);
        }
	}
	
	private void Update ()
    {
        if(m_aliveRacers.Count > 1)
        {
            for (int i = m_aliveRacers.Count - 1; i >= 0; --i)
            {
                if (m_aliveRacers[i].isDead)
                {
                    m_aliveRacers.RemoveAt(i);
                }
            }
        }
        else if(!m_winnerHasBeenDeclared && m_aliveRacers.Count == 1)
        {
            m_winnerName = m_aliveRacers[0].CarName;
            m_winnerHasBeenDeclared = true;
            GameController.m_instance.m_raceHasEnded = true;
            StartCoroutine("EndOfRace");
        }
	}
}
