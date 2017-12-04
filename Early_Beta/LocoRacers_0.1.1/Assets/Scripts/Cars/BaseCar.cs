using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCar : MonoBehaviour
{
    public string m_carName;
    public float m_carTurnSpeed = 200f;
    public float m_carSpeed = 800f;
    public float m_respawnTime = 1.4f;
    public bool m_hasTacos = false;
    public bool m_hasBoost = false;
    public bool m_isActive = true;
    public GameObject m_weaponSlot;
    protected Rigidbody m_rigidbody;
    protected MeshRenderer m_meshRenderer;
    private const float BOOST_SPEED = 50000f;
    public int m_wayPointCount = 0;
    public bool m_hasCrossedWayPoint;
    public int m_lapCount = 0;
    public float m_raceTime = 0;
    public bool m_isAnAi;
    public bool m_raceHasEnded = false;
    public Vector3 m_idlePosition;
    public bool m_hasBeenStopped;
    public WheelCollider m_wheel;

    IEnumerator TacosHit()
    {
        m_isActive = false;
        yield return new WaitForSeconds(m_respawnTime);
        m_isActive = true;
    }

    protected abstract void UseItem();
    protected abstract void CarMovement();

    protected void OnCollisionEnter(Collision acol)
    {
        if (acol.gameObject.layer == LayerMask.NameToLayer("Tacos"))
        {
            StartCoroutine("TacosHit");
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

    protected void SpawnObject(Transform aTransform, GameObject aGameObj)
    {
        GameObject go = Instantiate(aGameObj, aTransform);
        go.transform.parent = null;
        m_hasTacos = false;
    }
}
