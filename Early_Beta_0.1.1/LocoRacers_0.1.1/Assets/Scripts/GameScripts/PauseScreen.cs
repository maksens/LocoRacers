using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Button[] m_soundBtn;
    public AudioSource m_audioS;
    public Canvas m_pauseMenu;

    public void PauseGame()
    {
        GameController.m_instance.m_gameIsPaused = true;
        m_pauseMenu.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        GameController.m_instance.m_gameIsPaused = false;
        m_pauseMenu.gameObject.SetActive(false);
    }

    public void RestartGame(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void TurnOffSound()
    {
        m_audioS.mute = true;
        m_soundBtn[0].gameObject.SetActive(false);
        m_soundBtn[1].gameObject.SetActive(true);
    }

    public void TurnOnSound()
    {
        m_audioS.mute = false;
        m_soundBtn[0].gameObject.SetActive(true);
        m_soundBtn[1].gameObject.SetActive(false);
    }
}
