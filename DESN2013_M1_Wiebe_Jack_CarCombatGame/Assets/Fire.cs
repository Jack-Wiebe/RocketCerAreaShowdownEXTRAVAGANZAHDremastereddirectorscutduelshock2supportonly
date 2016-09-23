using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			col.gameObject.GetComponentInParent<Car_Shooting_System> ().Explode();

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
