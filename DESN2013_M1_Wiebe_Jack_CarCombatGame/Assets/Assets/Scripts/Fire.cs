using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float flickerTime;
	[SerializeField]
	private ParticleSystem part;
	private BoxCollider col;
	private Light light;

	// Use this for initialization
	void Start () {
		part = this.GetComponent<ParticleSystem> ();
		col = this.GetComponent<BoxCollider> ();
		light = this.GetComponentInChildren<Light> ();
		StartCoroutine (Flicker ());
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			col.gameObject.GetComponentInParent<Car_Shooting_System> ().Explode();
			this.gameObject.SetActive (false);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator Flicker()
	{
		bool isOn = false;
		while(true)
		{
			yield return new WaitForSeconds (flickerTime);
			if (!isOn) {
				col.enabled = true;
				part.Play ();
				light.enabled = true;
				isOn = true;
			} else {
				part.Stop ();
				isOn = false;
				light.enabled = false;
				col.enabled = false;
			}
		}
	}
}
