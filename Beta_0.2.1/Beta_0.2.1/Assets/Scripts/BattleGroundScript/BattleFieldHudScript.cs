using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFieldHudScript : MonoBehaviour
{
    public Image[] m_lightsImg;
    public Image[] m_objectsImg;
    public Image m_square;
    public Image[] m_hpImages;
    public int m_nbHp = 3;

    public void Start()
    {
        StartCoroutine("RaceStart");
    }

    public void Update()
    {
        if (!GameController.m_instance.m_playerCar.isDead)
            ShowItem();
        else
        {
            m_square.gameObject.SetActive(false);
            m_objectsImg[0].gameObject.SetActive(false);
        }

        LoseHP();
    }


    IEnumerator RaceStart()
    {
        m_lightsImg[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        m_lightsImg[1].gameObject.SetActive(true);
        m_lightsImg[0].gameObject.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        m_lightsImg[2].gameObject.SetActive(true);
        m_lightsImg[1].gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        m_lightsImg[2].gameObject.SetActive(false);
        GameController.m_instance.StartTheRace();
    }

    public void ShowItem()
    {
        if (GameController.m_instance.m_playerCar.HasTacos)
        {
            m_objectsImg[0].gameObject.SetActive(true);
        }
        else
        {
            m_objectsImg[0].gameObject.SetActive(false);
        }
    }

    public void LoseHP()
    {
        if (m_nbHp < 3 && m_nbHp >= 0)
        {
            m_hpImages[2 - m_nbHp].gameObject.SetActive(false);
            m_hpImages[5 - m_nbHp].gameObject.SetActive(true);
        }
    }
}
