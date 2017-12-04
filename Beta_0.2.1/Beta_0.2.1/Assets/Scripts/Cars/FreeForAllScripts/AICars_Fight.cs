using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICars_Fight : BaseCar
{
    public LayerMask m_layers;
    public Vector3 m_currentItemPosition;
    public LinkedList<BaseCar> m_targets;
    public BaseCar m_currentTarget;
    public bool m_isLookingForItem = true;
    public bool m_isLookingForTarget = false;
    public bool m_isChasingTarget = false;
    public bool m_isDead = false;
    public bool m_isWinner = false;


    private void Start()
    {
        CarName = "AI # " + GameController.m_instance.m_nbOfAi++;
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponent<MeshRenderer>();
        IsAnAi = false;
        m_deathMatch = true;
    }

    private void FixedUpdate()
    {
        if(m_nbOfLives > 0)
        {
            m_raceTime += Time.deltaTime;
            if (GameController.m_instance.m_raceHasStarted && m_isActive && !m_isWinner)
            {
                if (m_isLookingForItem)
                {
                    m_currentItemPosition = ChooseItem();
                    CarMove(m_currentItemPosition);


                    if (HasBoost || HasTacos)
                    {
                        m_isLookingForItem = false;
                        m_isLookingForTarget = true;
                    }
                }
                else if (m_isLookingForTarget)
                {
                    m_currentTarget = ChooseTarget();

                    if (m_currentTarget == this)
                    {
                        m_isWinner = true;
                    }
                    else
                        m_isLookingForTarget = false;
                }
                else
                {
                    CarMove(m_currentTarget.transform.position);
                    UseItem();
                }
            }
            else if (!m_isActive && !GameController.m_instance.m_gameIsPaused)
            {
                transform.Rotate(Vector3.up * 10f);
            }
        }
        else
        {
            if (!m_hasBeenStopped)
            {
                m_fx.SetActive(true);
                m_wheel.motorTorque = 0;
                isDead = true;
            }
        }

        if(m_isWinner)
        {
            m_isActive = false;
        }

        if (GameController.m_instance.m_gameIsPaused)
        {
            if (!m_hasBeenStopped)
            {
                m_idlePosition = transform.position;
                m_hasBeenStopped = true;
            }
            else
            {
                transform.position = m_idlePosition;
            }
        }
    }

    protected override void UseItem()
    {
        if (m_hasTacos && Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers) && !GameController.m_instance.m_gameIsPaused)
        {
            GameObject go = SpawnObject(m_weaponSlot.transform, GameController.m_instance.m_weapons[0]);
            TacoScript t = go.GetComponent<TacoScript>();
            t.m_owner = gameObject;
            m_isLookingForItem = true;

        }
        if (m_hasBoost && !Physics.Raycast(m_weaponSlot.transform.position, transform.forward, 10f, m_layers) && !GameController.m_instance.m_gameIsPaused)
        {
            UseBoost(transform, m_rigidbody);
            m_isLookingForItem = true;
        }
    }

    private void CarMove(Vector3 v)
    {
        if (m_wheel.motorTorque >= m_carSpeed)
            m_wheel.motorTorque = m_carSpeed;
        else
            m_wheel.motorTorque += 50 * Time.deltaTime;

        RotateCarAI(v, transform, m_carTurnSpeed);
    }

    protected override void CarMovement()
    {
    }

    private BaseCar ChooseTarget()
    {
        m_targets = new LinkedList<BaseCar>();

        foreach(GameObject go in GameController.m_instance.m_baseCars.Keys)
        {
            if(go != gameObject && !GameController.m_instance.m_baseCars[go].isDead)
            {
                if (m_targets.First == null)
                {
                    m_targets.AddFirst(GameController.m_instance.m_baseCars[go]);
                }
                else if (Vector3.Distance(go.transform.position, transform.position) <
                        Vector3.Distance(m_targets.First.Value.transform.position, transform.position))
                {
                    m_targets.AddFirst(GameController.m_instance.m_baseCars[go]);
                }
            }
        }

        if (m_targets.Count > 0)
            return m_targets.First.Value;
        else
            return this;
    }

    private Vector3 ChooseItem()
    {
        Vector3 v = new Vector3(10000, 10000, 10000);

        foreach(GameObject go in GameController.m_instance.m_wayPoints)
        {
            if(Vector3.Distance(go.transform.position, transform.position) <
               Vector3.Distance(v, transform.position))
                    v = go.transform.position;
        }

        return v;
    }
}
