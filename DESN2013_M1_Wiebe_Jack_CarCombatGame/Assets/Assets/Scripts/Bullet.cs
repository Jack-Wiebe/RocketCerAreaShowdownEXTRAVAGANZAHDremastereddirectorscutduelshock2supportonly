using UnityEngine;
using System.Collections;

public class Bullet : Projectile_Base {

	[SerializeField] private Vector3 m_initialPos;
	[SerializeField] private Vector3 m_dir;
	[SerializeField] private float m_bulletSpeed;
	[SerializeField] private float m_bulletLife;
	[SerializeField] private GameObject m_car;
	[SerializeField] private float m_dmg = 5.0f;

	//Collision related variables
	[SerializeField] private LayerMask m_mask;
	[SerializeField] private int m_enemyLayer;

	//Run when car is instantiated
	void Awake(){
		m_car = GameObject.FindGameObjectWithTag ("Player");
	}
	//Run Everytime the Bullet is enabled
	void OnEnable () {
		StartCoroutine (DestroyMe());
	}
	//Run Everytime the Bullet is disabled
	void OnDisable () {
		StopAllCoroutines ();
	}
	public void findPlayer(GameObject player)
	{
		m_car = player;
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds (m_bulletLife);
		this.gameObject.SetActive (false);
			
	}

	void OnTriggerEnter(Collider target)
	{
		if ((m_mask.value & 1 << target.gameObject.layer) == target.gameObject.layer) {
			Bullet_Hit (m_car, target.gameObject, m_dmg);
		}
	}

	override public void Bullet_Hit(GameObject instigator, GameObject target, float dmg)
	{

		if (instigator == null)
			Debug.Log ("No instigator found");
		
	}

	public float ChangeDamage(float modifier)
	{
		m_dmg += modifier;
		if (m_dmg < 0)
			m_dmg = 0;
		return (m_dmg);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.forward * (m_bulletSpeed * Time.deltaTime);
	}
}
