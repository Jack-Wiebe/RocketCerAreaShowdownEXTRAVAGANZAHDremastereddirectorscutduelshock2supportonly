using UnityEngine;
using System.Collections;

public class Turret_Tracking : MonoBehaviour {

	[SerializeField] private float m_speed;
	[SerializeField] private GameObject m_target;
	[SerializeField] private Turret_AI m_turret;
	private Vector3 m_targetLocation;
	private Quaternion m_rotarion;
	private float m_distTo;


	void Start()
	{
		m_turret = this.GetComponent<Turret_AI> ();
		m_target = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () {
		if (m_targetLocation != m_target.transform.position) {
			m_targetLocation = m_target.transform.position;
			m_distTo = (m_targetLocation - this.transform.position).magnitude;
			m_rotarion = Quaternion.LookRotation (m_targetLocation - this.transform.position);
		}
		if (this.transform.rotation != m_rotarion && m_turret.isTargetInRange)
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, m_rotarion, m_speed * Time.deltaTime);

	}
	bool SetTarget(GameObject target){
		if (!target)
			return false;

		m_target = target;

		return true;
	}
	public float GetDistance()
	{
		return m_distTo;
	}


}
