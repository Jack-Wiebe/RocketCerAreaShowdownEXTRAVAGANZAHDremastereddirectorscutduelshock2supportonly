using UnityEngine;
using System.Collections;

public class Halo_glow : MonoBehaviour {

	MeshRenderer mesh;
	float range;
	public float delta;
	bool growing;

	// Use this for initialization
	void Start () {
		mesh = this.GetComponent<MeshRenderer> ();
		range = 0.0f;
		growing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (growing)
			range += delta;
		else
			range -= delta;
		if (range >= 1.0f)
			growing = false;
		else if( range <= 0)
			growing = true;
		mesh.material.SetFloat ("_MKGlowTexStrength", range);
	}
}
