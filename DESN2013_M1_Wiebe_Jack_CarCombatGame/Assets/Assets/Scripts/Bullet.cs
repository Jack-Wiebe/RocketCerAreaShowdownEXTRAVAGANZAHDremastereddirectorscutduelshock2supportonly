using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[SerializeField] private Vector3 _initialPos;
	[SerializeField] private Vector3 _dir;
	[SerializeField] private float _bulletSpeed;
	[SerializeField] private float _bulletLife;



	// Use this for initialization
	void Start () {
		_initialPos = this.transform.position;
		StartCoroutine (DestroyMe());
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds (_bulletLife);
		Destroy (this.gameObject);
			
	}

	// Update is called once per frame
	void Update () {
		this.transform.position += (_bulletSpeed * _dir);
	}
}
