using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

	public float rotSpeed;
	public float moveSpeed;
	public Transform pointA;
	public Transform pointB;

	public Transform Target;

	public Vector3 destVec;
	public bool isForward = true;

	// Use this for initialization
	void Start () {
		//Target = pointA;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			col.gameObject.GetComponentInParent<Car_Shooting_System> ().Explode();
			//this.gameObject.SetActive (false);

		}
	}

	// Update is called once per frame
	void Update () {

		//this.transform.Rotate(Vector3.right * rotSpeed);

		if (isForward) {
			this.transform.Rotate(Vector3.right * rotSpeed);
			this.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime, Space.World);
		} else {
			this.transform.Rotate(Vector3.left * rotSpeed);
			this.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime, Space.World);
		}

		if (Vector3.Distance (this.transform.position, Target.position) <= 0.1f) {
			if (isForward) {
				Target = pointB;
				isForward = false;
			} else {
				Target = pointA;
				isForward = true;
			}
		}



	}
}
