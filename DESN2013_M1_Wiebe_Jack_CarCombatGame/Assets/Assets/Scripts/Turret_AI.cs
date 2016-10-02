using UnityEngine;
using System.Collections;

public class Turret_AI : MonoBehaviour {

	[SerializeField] private Turret_Firing m_t_fire;
	[SerializeField] private Turret_Tracking m_t_track;

	public float range;
	public bool isTargetInRange;

	// Use this for initialization
	void Start () {
		m_t_fire = this.GetComponent<Turret_Firing> ();
		m_t_track = this.GetComponent<Turret_Tracking> ();
	}
	
	// Update is called once per frame
	void Update () {

		isTargetInRange = (m_t_track.GetDistance() < range) ? true : false;
			
	}
}
