using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{


	public class Speedpad : MonoBehaviour {

		[SerializeField] private LayerMask m_mask;
		[SerializeField] private int m_enemyLayer;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnTriggerStay(Collider target)
		{
			if (target.CompareTag("Player")) {

				//Debug.Break ();
				target.attachedRigidbody.velocity = (this.transform.forward * 100.0f);


			}
		}
	}
}
