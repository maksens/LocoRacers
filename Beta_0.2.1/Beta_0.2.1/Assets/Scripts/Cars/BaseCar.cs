using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCar : MonoBehaviour
{
    protected string m_carName;
    protected bool m_deathMatch;
    protected bool m_hasBeenStopped;
    protected bool m_hasBoost = false;
    public bool m_hasCrossedWayPoint;
    protected bool m_hasBeenHit = false;
    protected bool m_hasTacos = false;
    protected bool m_isAnAi;
    protected bool m_isActive = true;
    public bool isDead = false;
    protected bool m_raceHasEnded = false;
    private const float BOOST_SPEED = 50000f;
    public float m_carSpeed = 800f;
    public float m_carTurnSpeed = 200f;
    public float m_raceTime = 0;
    public float m_respawnTime = 1.4f;
    public int m_lapCount = 0;
    public int m_nbOfLives = 3;
    public int m_wayPointCount = 0;
    public GameObject m_weaponSlot;
    public GameObject m_fx;
    public GameObject m_tireSpawn;
    protected Rigidbody m_rigidbody;
    protected MeshRenderer m_meshRenderer;
    public Vector3 m_idlePosition;
    public WheelCollider m_wheel;

    public bool IsAnAi { get { return m_isAnAi; } protected set { m_isAnAi = value; } }
    public bool HasBoost { get { return m_hasBoost; } set { m_hasBoost = value; } }
    public bool HasRaceEnded { get { return m_raceHasEnded; } set { m_raceHasEnded = value; } }
    public bool HasTacos { get { return m_hasTacos; } set { m_hasTacos = value; } }
    public string CarName { get { return m_carName; } protected set { m_carName = value; } }

    IEnumerator TacosHit()
    {
        if(m_nbOfLives > 0 && m_deathMatch)
        {
            m_hasBeenHit = true;
            m_nbOfLives--;
        }

        m_isActive = false;
        yield return new WaitForSeconds(m_respawnTime);
        m_isActive = true;
        m_hasBeenHit = false;
    }

    protected abstract void UseItem();
    protected abstract void CarMovement();

    protected void OnCollisionEnter(Collision acol)
    {
        if (acol.gameObject.layer == LayerMask.NameToLayer("Tacos"))
        {
            TacoScript t = acol.gameObject.GetComponent<TacoScript>();
            if (t.m_owner != GameController.m_instance.m_baseCars[t.m_owner] && !m_hasBeenHit)
            {
                StartCoroutine("TacosHit");
            }
        }
    }

    protected void RotateCar(Vector3 aOrientation, Transform aTransform, float aTurnSpeed)
    {
        if (Vector3.Cross(aOrientation - aTransform.forward, aOrientation).y < Vector3.zero.y - 0.05)
        {
            aTransform.Rotate(Vector3.up * aTurnSpeed * Time.deltaTime);
        }
        else if (Vector3.Cross(aOrientation - aTransform.forward, aOrientation).y > Vector3.zero.y + 0.05)
        {
            aTransform.Rotate(-Vector3.up * aTurnSpeed * Time.deltaTime);
        }
    }

    protected void RotateCarAI(Vector3 aOrientation, Transform aTransform, float aTurnSpeed)
    {
        if (Vector3.Cross(aOrientation - aTransform.position, aTransform.forward).y < Vector3.zero.y - 0.05)
        {
            aTransform.Rotate(Vector3.up * aTurnSpeed * Time.deltaTime);
        }
        else if (Vector3.Cross(aOrientation - aTransform.position, aTransform.forward).y > Vector3.zero.y + 0.05)
        {
            aTransform.Rotate(-Vector3.up * aTurnSpeed * Time.deltaTime);
        }
    }

    protected void UseBoost(Transform aTransform, Rigidbody aRigid)
    {
        aRigid.AddForce(aTransform.forward * BOOST_SPEED);
        m_hasBoost = false;
    }

    protected GameObject SpawnObject(Transform aTransform, GameObject aGameObj)
    {
        GameObject go = Instantiate(aGameObj, aTransform);
        go.transform.parent = null;
        m_hasTacos = false;
        return go;
    }
}
