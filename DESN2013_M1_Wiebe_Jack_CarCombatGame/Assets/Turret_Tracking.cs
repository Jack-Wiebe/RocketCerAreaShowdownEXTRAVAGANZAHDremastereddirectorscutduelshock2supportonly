using UnityEngine;
using System.Collections;

public class Turret_Tracking : MonoBehaviour {

	[SerializeField] private float m_speed;
	[SerializeField] private GameObject m_target;
	private Vector3 m_targetLocation;
	private Quaternion m_rotarion;
	
	// Update is called once per frame
	void Update () {
		if (m_targetLocation != m_target.transform.position) {
			m_targetLocation = m_target.transform.position;
			m_rotarion = Quaternion.LookRotation (m_targetLocation - this.transform.position);
		}
		if (this.transform.rotation != m_rotarion)
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, m_rotarion, m_speed * Time.deltaTime);

	}
	bool SetTarget(GameObject target){
		if (!target)
			return false;

		m_target = target;

		return true;
	}


}
