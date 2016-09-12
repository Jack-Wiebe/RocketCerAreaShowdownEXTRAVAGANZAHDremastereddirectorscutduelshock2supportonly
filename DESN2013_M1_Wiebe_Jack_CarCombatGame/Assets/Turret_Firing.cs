using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret_Firing : MonoBehaviour {

	[SerializeField] private float m_fireRate;
	[SerializeField] private GameObject m_bullet;
	[SerializeField] private Transform m_barrel;

	[SerializeField] private GameObject m_target;
	[SerializeField] private float m_fieldOfView;

	[SerializeField] private  int m_poolSize;
	public List<GameObject> bulletPool;
	private IEnumerator coroutine;

	private bool m_firing = false;

	// Use this for initialization
	void Start () {
		SpawnBulletPool ();
		coroutine = Firing ();
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Quaternion.Angle(this.transform.rotation,
			Quaternion.LookRotation(m_target.transform.position - this.transform.position));

		if (angle < m_fieldOfView && !m_firing) {
			StartCoroutine (coroutine);
			m_firing = true;
		} else if (angle > m_fieldOfView) {
			StopCoroutine (coroutine);
			m_firing = false;
		}
	}

	private IEnumerator Firing()
	{
		while(true)
		{
			yield return new WaitForSeconds (m_fireRate);
			FireWeapon ();

		}
	}

	public void FireWeapon()
	{
		for (int i = 0; i < bulletPool.Count; i++) {
			if (!bulletPool [i].activeInHierarchy) {

				bulletPool [i].transform.position = m_barrel.position;

				Quaternion ang = Quaternion.Euler (0.0f, this.transform.rotation.eulerAngles.y, 0.0f);
				bulletPool [i].transform.rotation = ang;

				bulletPool [i].SetActive (true);
				return;
			}
		}
	}

	public void SpawnBulletPool ()
	{
		if (!m_bullet)
			return;

		for (int i = 0; i < m_poolSize; i++) {
			GameObject obj = (GameObject)Instantiate (m_bullet);
			obj.SetActive (false);
			bulletPool.Add (obj);
		}

	}
}
