﻿using UnityEngine;
using System.Collections;

public class COLOR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;
		Color[] colors = new Color[vertices.Length];

		for (int i = 0; i < vertices.Length; i++) {
			colors [i] = Color.Lerp (Color.red, Color.green, vertices [i].y);
		}
		mesh.colors = colors;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
