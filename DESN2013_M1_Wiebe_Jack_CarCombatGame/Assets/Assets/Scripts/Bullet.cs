using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[SerializeField] private Vector3 _initialPos;
	[SerializeField] private Vector3 _dir;
	[SerializeField] private float _bulletSpeed;
	[SerializeField] private float _bulletLife;
	[SerializeField] private GameObject _car;



	// Use this for initialization
	void OnEnable () {
		StartCoroutine (DestroyMe());
	}
	void OnDisable () {
		StopAllCoroutines ();
	}
	public void findPlayer(GameObject player)
	{
		_car = player;
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds (_bulletLife);
		this.gameObject.SetActive (false);;
			
	}

	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.forward * (_bulletSpeed * Time.deltaTime);
	}
}
