using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class Speedpad_glow : MonoBehaviour {

	[SerializeField] private float speed;
	private Material m;

	void Start() {
		m = GetComponent<MeshRenderer>().material;
	}

	void Update() {
		Vector2 offset = new Vector2(0, Time.time * speed % 1);
		m.SetTextureOffset("_MainTex", offset);
	}
}

