using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	public class Car_Shooting_System : MonoBehaviour {

		[SerializeField] private float _fireDelay = 0.5f;
		[SerializeField] private bool _rightGunFiring;
		[SerializeField] private Transform gunRight;
		[SerializeField] private Transform gunLeft;
		[SerializeField] private GameObject _bullet;

		[SerializeField] private int _bulletPoolNum = 100;
		[SerializeField] private List<GameObject> Bullets;



		[SerializeField]
		private GameObject m_car;

		[SerializeField]
		private Rigidbody[] rigidArray ;
		private IEnumerator coroutine;

		// Use this for initialization
		void Start () {
			coroutine = Firing ();

			//create object pool
			Bullets = new List<GameObject> ();
			for (int i = 0; i < _bulletPoolNum; i++) {
				GameObject obj = (GameObject)Instantiate (_bullet);
				obj.SetActive (false);
				Bullets.Add (obj);
			}
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void Explode()
		{
			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			m_car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController> ().Move (0, 0, 0, 1000);
			foreach(Rigidbody rigid in rigidArray)
			{
				rigid.velocity = Vector3.zero;
				rigid.transform.parent = null;
				rigid.isKinematic = false;
				rigid.useGravity = true;
				//Debug.Break ();
				rigid.AddForce(Random.Range (-100, 100), Random.Range (300, 500), Random.Range (-100, 100) );
			}
		m_car.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl> ().enabled = false;
		m_car.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio> ().pitchMultiplier = 0.0f;
			
		}

		public void ShootOn()
		{

			StartCoroutine (coroutine);
		}

		public void ShootOff()
		{
			Debug.Log ("Break");
			StopCoroutine (coroutine);
		}

		public IEnumerator Firing()
		{

			//determines what gun is currently firing
			//searches objpool for unused bullet to fire
			while (true) {

				yield return new WaitForSeconds (_fireDelay);

				for (int i = 0; i < Bullets.Count; i++) {

					if (!Bullets [i].activeInHierarchy) {

						if (_rightGunFiring) {
							Bullets [i].transform.position = gunRight.position;
							_rightGunFiring = false;
						} else {
							Bullets [i].transform.position = gunLeft.position;
							_rightGunFiring = true;
						}

					Quaternion ang = Quaternion.Euler (this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
						Bullets [i].transform.rotation = ang;

						Bullets [i].SetActive (true);

						//i = Bullets.Count;
						break;

					}
				}

				Debug.Log (_fireDelay);

				//Debug.Break ();
				//yield return new WaitForSeconds (_fireDelay);

			}
		}
	}
