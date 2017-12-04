using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoScript : MonoBehaviour
{
    public const float TACO_POWER = 5000f;
    private Rigidbody m_rigidbody;

	private void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
    {
        m_rigidbody.AddForce(transform.forward * TACO_POWER * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
