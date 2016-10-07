using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Car_Controller : MonoBehaviour {
		
	[SerializeField] private Rigidbody m_rRef;
	private float m_deadzone = 0.01f;

	public float linearAccForward = 100.0f;
	public float linearAccBackward = 25.0f;
	private float m_thrust = 0.0f;

	public float rotSpeed = 10f;
	private float m_rotation = 0.0f;

	[SerializeField]private LayerMask m_layerMask;
	public float m_suspensionForce = 9.0f;
	public float m_suspensionHeight = 2.0f;
	public GameObject[] wheels;


	void Start () {
		m_rRef = GetComponent<Rigidbody> ();

		m_layerMask = 1 << LayerMask.NameToLayer ("Player");
		m_layerMask = ~m_layerMask;
	}

	// Update is called once per frame
	void Update () {




	}

	void OnDrawGizmos()
	{
		Debug.Log ("drawing");
		RaycastHit hit;
		for (int i = 0; i < wheels.Length; i++)
		{
			GameObject wheel = wheels [i];
			if (Physics.Raycast(wheel.transform.position, 
				-Vector3.up, out hit,
				m_suspensionHeight, 
				m_layerMask))
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(wheel.transform.position, hit.point);
				Gizmos.DrawSphere(hit.point, 0.5f);
			} else
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(wheel.transform.position, 
					wheel.transform.position - Vector3.up * m_suspensionHeight);
			}
		}
	}

	public void Move(float h, float v)
	{
		
		//float accIn = v;
		m_thrust = 0.0f;
		if (v > m_deadzone) {
			m_thrust = v * linearAccForward;
		} else if (v < -m_deadzone) {
			m_thrust = v * linearAccBackward;
		}

		//float rotIn = h;
		m_rotation = 0.0f;
		if (Mathf.Abs(h) > m_deadzone) {
			m_rotation = h;
		}
		//Debug.Log (m_rotation);


	}

	void FixedUpdate()
	{
		if (Mathf.Abs (m_thrust) > 0)
			m_rRef.AddForce (this.transform.forward * m_thrust);

		if (m_rotation != 0 ) {
			m_rRef.AddRelativeTorque (Vector3.up * m_rotation * rotSpeed);
		}
		//else 

		RaycastHit hit;
		for (int i = 0; i < wheels.Length; i++) {
			GameObject tempWheel = wheels [i];
			//Debug.Log (tempWheel);
			if (Physics.Raycast (tempWheel.transform.position, -Vector3.up, out hit, m_suspensionHeight, m_layerMask)) {
				//Debug.Log (hit.distance);
				m_rRef.AddForceAtPosition (Vector3.up * m_suspensionForce * ( 1.0f - (hit.distance / m_suspensionHeight)), tempWheel.transform.position);
			} else {
				//Debug.Log (hit.transform.gameObject);
				if (this.transform.position.y > tempWheel.transform.position.y) {
					m_rRef.AddForceAtPosition (tempWheel.transform.up * m_suspensionForce, tempWheel.transform.position);
				} else {
					m_rRef.AddForceAtPosition (tempWheel.transform.up * -m_suspensionForce, tempWheel.transform.position);
				}
			}
		}

	}
}
