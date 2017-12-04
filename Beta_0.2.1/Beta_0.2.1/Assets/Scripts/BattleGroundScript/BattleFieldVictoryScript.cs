using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFieldVictoryScript : MonoBehaviour
{
    public Text m_winnerText;
    public Canvas m_victoryCanvas;

    public void StartTyping()
    {
        StartCoroutine("TypeWriter");
    }

    IEnumerator TypeWriter()
    {
        string winner = GameController.m_instance.m_lastManScript.m_winnerName;

        for (int i = 0; i < winner.Length; i++)
        {
            m_winnerText.text += winner[i];
            yield return new WaitForSeconds(0.35f);
        }
    }

}
